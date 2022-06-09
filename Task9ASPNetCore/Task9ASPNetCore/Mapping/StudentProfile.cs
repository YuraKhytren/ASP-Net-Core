using AutoMapper;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Infrastructure.Busines.DTO;
using Task9ASPNetCore.ViewModels;

namespace Task9ASPNetCore.Mapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<StudentDTO, StudentViewModel>()
                .ForMember("FirstName", opt => opt.MapFrom(src => src.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(src => src.LastName))
                .ForMember("Patronymic", opt => opt.MapFrom(src => src.Patronymic));

            CreateMap<StudentViewModel, StudentDTO>()
                .ForMember("FirstName", opt => opt.MapFrom(src => src.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(src => src.LastName))
                .ForMember("Patronymic", opt => opt.MapFrom(src => src.Patronymic));
        }
    }
}
