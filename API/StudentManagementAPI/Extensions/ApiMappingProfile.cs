using AutoMapper;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Enums;
using StudentManagementAPI.Models;
using System.Linq;

namespace StudentManagementAPI.Extensions
{ 
    public class ApiMappingProfile : AutoMapper.Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<ScoreDto, Score>();
            CreateMap<HomeworkDto, Homework>();
            CreateMap<ExerciseCreateDto, Exercise>();
            CreateMap<Score, ScoreViewDto>()
                .ForMember(x=>x.SemesterName, act=>act.MapFrom(src=>src.SemesterNavigation.Name))
                .ForMember(x => x.TestTypeName, act => act.MapFrom(src => src.TestTypeNavigation.TestName))
                .ForMember(x => x.StudentName, act => act.MapFrom(src => src.StudentNavigation.AppUser.FullName))
                .ForMember(x => x.SubjectName, act => act.MapFrom(src => src.SubjectNavigation.Name));


            CreateMap<Homework, HomeworkDetailDto>()
                .ForMember(x => x.UserFullName, act => act.MapFrom(src => src.UserNavigation.FullName))
                .ForMember(x=>x.SubjectName, act => act.MapFrom(src => src.UserNavigation.TeacherNavigation.SubjectNavigation.Name))
                .ForMember(x => x.Sources, act => act.MapFrom(src => src.Source.ToList()));

            CreateMap<Exercise, ExerciseDto>()
                .ForMember(x => x.UserName, act => act.MapFrom(src => src.UserNavigation.FullName))
                .ForMember(x => x.AvatarPath, act => act.MapFrom(src => src.UserNavigation.AvatarPath))
                .ForMember(x => x.UserId, act => act.MapFrom(src => src.UserId))
                .ForMember(x => x.Sources, act => act.MapFrom(src => src.Sources.ToList()));

            CreateMap<AppUser, UserInfoDto>()
               .ForMember(x => x.AvatarPath, act => act.MapFrom(src => $"assets\\uploads\\{PathEnum.Avatar}\\{src.Id}\\" + src.AvatarPath))
               .ForMember(x => x.TeamId, act => act.MapFrom(src => src.StudentNavigation.TeamId))
               .ForMember(x => x.TeacherId, act => act.MapFrom(src => src.TeacherNavigation.Id))
               .ForMember(x => x.StudentId, act => act.MapFrom(src => src.StudentNavigation.Id))
               .ForMember(x => x.IsStudent, act => act.MapFrom(src => src.TeacherNavigation==null?true:false));
        }
    }
}
