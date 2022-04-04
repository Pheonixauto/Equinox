using Equinox.Domain.Commands.Department.Events;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Department.Validations
{
    public class DepartmentCommandHandler : CommandHandler, IRequestHandler<RegisterNewDepartmentCommand, ValidationResult>,
                                                            IRequestHandler<UpdateDepartmentCommand, ValidationResult>,
                                                            IRequestHandler<RemoveDepartmentCommand, ValidationResult>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewDepartmentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var department = new Models.Department(Guid.NewGuid(), message.Name);

            if (await _departmentRepository.GetByName(department.Name) != null)
            {
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            department.AddDomainEvent(new DepartmentRegisteredEvent(department.Id, department.Name));

            _departmentRepository.Add(department);

            return await Commit(_departmentRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateDepartmentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var department = new Models.Department(message.Id, message.Name);
            var existingDepartment = await _departmentRepository.GetByName(department.Name);

            if (existingDepartment != null && existingDepartment.Id != department.Id)
            {
                if (!existingDepartment.Equals(department))
                {
                    AddError("The department Name has already been taken.");
                    return ValidationResult;
                }
            }

            department.AddDomainEvent(new DepartmentUpdatedEvent(department.Id, department.Name));

            _departmentRepository.Update(department);

            return await Commit(_departmentRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveDepartmentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var department = await _departmentRepository.GetById(message.Id);

            if (department is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            department.AddDomainEvent(new DepartmentRemovedEvent(message.Id));

            _departmentRepository.Remove(department);

            return await Commit(_departmentRepository.UnitOfWork);
        }
    }
}
