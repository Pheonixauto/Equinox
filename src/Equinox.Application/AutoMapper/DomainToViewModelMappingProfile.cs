using AutoMapper;
using Equinox.Application.DTO;
using Equinox.Application.ViewModels;
using Equinox.Domain.Models;

namespace Equinox.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Employee, ImportEmployeeDTO>().ReverseMap();

            CreateMap<Department, DepartmentViewModel>();
            CreateMap<Relative, RelativeViewModel>();
            CreateMap<Salary, SalaryViewModel>();
            CreateMap<Learning,LearningViewModel>();
            CreateMap<EmployeeLearning, EmployeeLearningViewModel>();
            CreateMap<Skill, SkillViewModel>();
            CreateMap<EmployeeSkill, EmployeeSkillViewModel>();

        }
    }
}
