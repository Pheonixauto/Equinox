using Equinox.Domain.Commands.Relative.Events;
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

namespace Equinox.Domain.Commands.Relative
{
    public class RelativeCommandHandler : CommandHandler, IRequestHandler<RegisterNewRelativeCommand, ValidationResult>
    {
        private readonly IRelativeRepository _relativeRepository;

        public RelativeCommandHandler(IRelativeRepository relativeRepository)
        {
           _relativeRepository = relativeRepository;
        }
        public async Task<ValidationResult> Handle(RegisterNewRelativeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var relative = new Models.Relative(Guid.NewGuid(), message.Name, message.Email, message.BirthDate, message.EmployeeId);

            if (await _relativeRepository.GetByEmail(relative.Email) != null)
            {
                AddError("The relative e-mail has already been taken.");
                return ValidationResult;
            }

            relative.AddDomainEvent(new RelativeRegisteredEvent(relative.Id, relative.Name, relative.Email, relative.BirthDate,relative.EmployeeId));

            _relativeRepository.Add(relative);

            return await Commit(_relativeRepository.UnitOfWork);
        }
    }
}
