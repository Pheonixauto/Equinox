using AutoMapper;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands;
using Equinox.Domain.Commands.Employee;

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
        }
    }
}
