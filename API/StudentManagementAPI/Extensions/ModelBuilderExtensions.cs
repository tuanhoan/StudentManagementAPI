using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System;

namespace StudentManagementAPI.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            },
             new
             {
                 Id = new Guid("7f0ac7fe-bb4e-4be2-941a-d368e3f9336a"),
                 ConcurrencyStamp = "807fd416-0522-4d8f-860d-5b85c4beec9b",
                 Description = "Student role",
                 Name = "student",
                 NormalizedName = "student"
             },
            new
            {
                Id = new Guid("22292118-048a-4673-a21f-2f3ae6fc9243"),
                ConcurrencyStamp = "f48b70c5-9c19-4311-9272-0891508ed235",
                Description = "Teacher role",
                Name = "teacher",
                NormalizedName = "teacher"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "tuanhoan",
                NormalizedUserName = "tuanhoan",
                Email = "tuanhoan@gmail.com",
                NormalizedEmail = "tuanhoan@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Anh@0986629359"),
                SecurityStamp = string.Empty,
                FullName = "Tuấn Hoàn",
                Birthday = new DateTime(2000, 04, 24)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
