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
            CreateMap<ExerciseDto, Exercise>();
            CreateMap<Score, ScoreViewDto>()
                .ForMember(x=>x.SemesterName, act=>act.MapFrom(src=>src.SemesterNavigation.Name))
                .ForMember(x => x.TestTypeName, act => act.MapFrom(src => src.TestTypeNavigation.TestName))
                .ForMember(x => x.StudentName, act => act.MapFrom(src => src.StudentNavigation.Name))
                .ForMember(x => x.SubjectName, act => act.MapFrom(src => src.SubjectNavigation.Name));


            CreateMap<Homework, HomeworkDetailDto>()
                .ForMember(x => x.UserFullName, act => act.MapFrom(src => src.UserNavigation.FullName))
                .ForMember(x => x.Sources, act => act.MapFrom(src => src.Source.ToList()));

        }
    }
}
