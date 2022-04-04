using Equinox.Domain.Commands.Employee.Events;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Employee
{
    public class EmployeeCommandHandler : CommandHandler, IRequestHandler<RegisterNewEmployeeCommand, ValidationResult>,
                                                          IRequestHandler<UpdateEmployeeCommand, ValidationResult>,
                                                          IRequestHandler<RemoveEmployeeCommand, ValidationResult>
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

            if (await _employeeRepository.GetByEmail(employee.Email) != null)
            {
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            employee.AddDomainEvent(new EmployeeRegisteredEvent(employee.Id, employee.Name, employee.Email, employee.BirthDate, employee.DepartmentId));

            _employeeRepository.Add(employee);

            return await Commit(_employeeRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateEmployeeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var employee = new Models.Employee(message.Id, message.Name, message.Email, message.BirthDate, message.DepartmentId);
            var existingEmployee = await _employeeRepository.GetByEmail(message.Email);

            if (existingEmployee != null && existingEmployee.Id != employee.Id)
            {
                if (!existingEmployee.Equals(employee))
                {
                    AddError("The customer e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            employee.AddDomainEvent(new EmployeeUpdatedEvent(employee.Id, employee.Name, employee.Email, employee.BirthDate, employee.DepartmentId));

            _employeeRepository.Update(employee);

            return await Commit(_employeeRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveEmployeeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var employee = await _employeeRepository.GetById(message.Id);

            if (employee is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            employee.AddDomainEvent(new EmployeeRemovedEvent(message.Id));

            _employeeRepository.Remove(employee);

            return await Commit(_employeeRepository.UnitOfWork);
        }
    }
}
