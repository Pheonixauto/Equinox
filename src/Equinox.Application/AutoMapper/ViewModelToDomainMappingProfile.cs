using AutoMapper;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands;
using Equinox.Domain.Commands.Department;
using Equinox.Domain.Commands.Employee;
using Equinox.Domain.Commands.Relative;

namespace Equinox.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            CreateMap<EmployeeViewModel, RegisterNewEmployeeCommand>()
               .ConstructUsing(c => new RegisterNewEmployeeCommand(c.Name, c.Email, c.BirthDate,c.DepartmentId));
            CreateMap<EmployeeViewModel, UpdateEmployeeCommand>()
               .ConstructUsing(c => new UpdateEmployeeCommand(c.Id, c.Name, c.Email, c.BirthDate,c.DepartmentId));

            CreateMap<DepartmentViewModel, RegisterNewDepartmentCommand>()
              .ConstructUsing(c => new RegisterNewDepartmentCommand(c.Name));
            CreateMap<DepartmentViewModel, UpdateDepartmentCommand>()
              .ConstructUsing(c => new UpdateDepartmentCommand(c.Id, c.Name));

            CreateMap<RelativeViewModel, RegisterNewRelativeCommand>()
             .ConstructUsing(c => new RegisterNewRelativeCommand(c.Name, c.Email, c.BirthDate,c.EmployeeId));
            CreateMap<RelativeViewModel, UpdateRelativeCommand>()
                .ConstructUsing(c => new UpdateRelativeCommand(c.Id,c.Name,c.Email,c.BirthDate,c.EmployeeId));
        }
    }
}
