using Equinox.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Employee
{
    public class EmployeeCommandHandler : CommandHandler, IRequestHandler<RegisterNewEmployeeCommand, ValidationResult>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewEmployeeCommand message, CancellationToken cancellationToken)
        {

            if (!message.IsValid()) return message.ValidationResult;

            var employee = new Models.Employee(Guid.NewGuid(), message.Name, message.Email, message.BirthDate, message.DepartmentId);

            //if (await _employeeRepository.GetByEmail(customer.Email) != null)
            //{
            //    AddError("The customer e-mail has already been taken.");
            //    return ValidationResult;
            //}

            //employee.AddDomainEvent(new EmployeeRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _employeeRepository.Add(employee);

            return await Commit(_employeeRepository.UnitOfWork);
        }
    }
}
