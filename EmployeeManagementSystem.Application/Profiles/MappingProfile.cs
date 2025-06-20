using AutoMapper;
using EmployeeManagementSystem.Application.Departments;
using EmployeeManagementSystem.Application.Employees;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Department, DepartmentVM>().ReverseMap();
        }

    }
}
