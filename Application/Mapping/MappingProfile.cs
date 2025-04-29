using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, RequestUser>().ReverseMap();

            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Employee, RequestEmployee>().ReverseMap();

            CreateMap<Department, DepartmentVM>().ReverseMap();
            CreateMap<Department, RequestDepartment>().ReverseMap();


        }
    }
}
