using AutoMapper;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Infrastructure.Busines.DTO;

namespace Task9ASPNetCore.Infrastructure.Busines.Mapping
{
    public class CourseToCourseDTOProfile : Profile
    {
        public CourseToCourseDTOProfile()
        {

            CreateMap<Course, CourseDTO>()
             .ForMember("NameDTO", opt => opt.MapFrom(src => src.Name))
             .ForMember("DescriptionDTO", opt => opt.MapFrom(src => src.Description));

            CreateMap<CourseDTO, Course>()
               .ForMember("Name", opt => opt.MapFrom(src => src.NameDTO))
               .ForMember("Description", opt => opt.MapFrom(src => src.DescriptionDTO));
        }
    }
}
