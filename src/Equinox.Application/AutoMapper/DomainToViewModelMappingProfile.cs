using AutoMapper;
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
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<Relative, RelativeViewModel>();
            CreateMap<Salary, SalaryViewModel>();
            CreateMap<Learning,LearningViewModel>();
            CreateMap<EmployeeLearning, EmployeeLearningViewModel>();
        }
    }
}
