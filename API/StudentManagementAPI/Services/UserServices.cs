using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Models;
using StudentManagementAPI.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public class UserServices
    {
        readonly StudentManagementContext _context;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<AppRole> _roleManager;
        private IConfiguration _config;
        public UserServices(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration config,
            StudentManagementContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }

        public async Task<(string, string, IList<string>, Guid)> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return (null, null, null, new Guid());
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return (null, null, null, new Guid());
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, String.Join(";", roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return (new JwtSecurityTokenHandler().WriteToken(token), user.UserName, roles, user.Id);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName,
                Birthday = request.Birthday,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var x = await _userManager.AddToRoleAsync(user, "student");
                return true;
            }
            return false;
        }

        public async Task<AppUser> GetCurrentUser(string usserName)
        {
            return await _context.Users.Where(x => x.UserName == usserName)
                .Include(x => x.TeacherNavigation)
                .Include(x => x.StudentNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<AppUser> UpdateInfo(Profile profile)
        {
            var user = await _userManager.FindByNameAsync(profile.username);

            user.FullName = profile.fullName;
            if (!String.IsNullOrEmpty(profile.birthday))
            {
                user.Birthday = Convert.ToDateTime(profile.birthday);
            }

            user.PhoneNumber = profile.phoneNumber;


            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task ResetPassword(string usserName)
        {
            var model = await _context.Users.Where(x => x.UserName == usserName).FirstOrDefaultAsync();
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(model);
            IdentityResult passwordChangeResult = await _userManager.ResetPasswordAsync(model, resetToken, model.UserName + "@LTT2022");
        }
    }
}
