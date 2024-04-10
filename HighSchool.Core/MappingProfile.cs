using AutoMapper;
using HighSchool.Core.Dtos;
using HighSchool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchool.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleEmployee, RoleEmployeeDto>().ReverseMap();
        }
    }
}
