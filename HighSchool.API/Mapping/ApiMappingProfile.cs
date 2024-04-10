using AutoMapper;
using HighSchool.API.Models;
using HighSchool.Core.Models;

namespace HighSchool.API.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>().ReverseMap(); 
            CreateMap<RoleEmployeePostModel, RoleEmployee>().ReverseMap(); 
            CreateMap<RolePostModel, Role>();
        }
    }
}
