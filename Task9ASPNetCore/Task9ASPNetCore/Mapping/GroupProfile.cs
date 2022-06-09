using AutoMapper;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Infrastructure.Busines.DTO;
using Task9ASPNetCore.ViewModels;

namespace Task9ASPNetCore.Mapping
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {

            CreateMap<GroupDTO, GroupViewModel>()
                    .ForMember("Name", opt => opt.MapFrom(src => src.Name))
                    .ForMember("CourseId", opt => opt.MapFrom(src => src.CourseId))
                    .ForMember("StudentCount", opt => opt.MapFrom(src => src.StudentCount));

            CreateMap<GroupViewModel, GroupDTO>()
               .ForMember("Name", opt => opt.MapFrom(src => src.Name))
               .ForMember("CourseId", opt => opt.MapFrom(src => src.CourseId))
               .ForMember("StudentCount", opt => opt.MapFrom(src => src.StudentCount));
        }
    }
}
