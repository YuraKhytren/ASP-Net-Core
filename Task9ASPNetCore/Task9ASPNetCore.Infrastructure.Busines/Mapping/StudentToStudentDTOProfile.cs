using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task9ASPNetCore.Domain.Core;
using Task9ASPNetCore.Infrastructure.Busines.DTO;

namespace Task9ASPNetCore.Infrastructure.Busines.Mapping
{
    public class StudentToStudentDTOProfile : Profile
    {
        public StudentToStudentDTOProfile() 
        {
            CreateMap<Student, StudentDTO>()
                .ForMember("FirstName", opt => opt.MapFrom(src => src.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(src => src.LastName))
                .ForMember("Patronymic", opt => opt.MapFrom(src => src.Patronymic));

            CreateMap<StudentDTO, Student>()
                .ForMember("FirstName", opt => opt.MapFrom(src => src.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(src => src.LastName))
                .ForMember("Patronymic", opt => opt.MapFrom(src => src.Patronymic));
        }
    }
}
