using AutoMapper;
using StudentManagementAPI.Dto;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Extensions
{ 
    public class ApiMappingProfile : AutoMapper.Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<ScoreDto, Score>();
            CreateMap<Score, ScoreViewDto>()
                .ForMember(x=>x.SemesterName, act=>act.MapFrom(src=>src.SemesterNavigation.Name))
                .ForMember(x => x.TestTypeName, act => act.MapFrom(src => src.TestTypeNavigation.TestName))
                .ForMember(x => x.StudentName, act => act.MapFrom(src => src.StudentNavigation.Name))
                .ForMember(x => x.SubjectName, act => act.MapFrom(src => src.SubjectNavigation.Name)); 
                
        }
    }
}
