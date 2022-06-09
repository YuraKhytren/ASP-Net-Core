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
    public class GroupToGroupDTOProfile : Profile
    {
        public GroupToGroupDTOProfile() 
        {
            CreateMap<Group, GroupDTO>()
                .ForMember("Name", opt => opt.MapFrom(src => src.Name))
                .ForMember("CourseId", opt => opt.MapFrom(src => src.CourseId))
            .ForMember("StudentCount", opt => opt.MapFrom(src => src.Students.Count));

            CreateMap<GroupDTO, Group>()
               .ForMember("Name", opt => opt.MapFrom(src => src.Name))
               .ForMember("CourseId", opt => opt.MapFrom(src => src.CourseId));
        }
    }
}
