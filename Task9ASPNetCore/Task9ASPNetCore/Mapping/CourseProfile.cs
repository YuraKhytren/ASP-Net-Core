using AutoMapper;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Infrastructure.Busines.DTO;
using Task9ASPNetCore.ViewModels;

namespace Task9ASPNetCore.Mapping
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDTO, CourseViewModel>()
                .ForMember("Name", opt => opt.MapFrom(src => src.NameDTO))
                .ForMember("Description", opt => opt.MapFrom(src => src.DescriptionDTO));

            CreateMap<CourseViewModel, CourseDTO>()
                .ForMember("NameDTO", opt => opt.MapFrom(src => src.Name))
                .ForMember("DescriptionDTO", opt => opt.MapFrom(src => src.Description));
        }
    }
}
