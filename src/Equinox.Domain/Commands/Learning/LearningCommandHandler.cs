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

namespace Equinox.Domain.Commands.Learning
{
    public class LearningCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewLearningCommand, ValidationResult>,
        IRequestHandler<UpdateLearningCommand, ValidationResult>,
        IRequestHandler<RemoveLearningCommand,ValidationResult>
    {
        private readonly ILearningRepository _learningRepository;

        public LearningCommandHandler(ILearningRepository learningRepository)
        {
            _learningRepository= learningRepository;
        }
        public async Task<ValidationResult> Handle(RegisterNewLearningCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var learning = new Models.Learning(Guid.NewGuid(),message.University);

            if (await _learningRepository.GetByUniversity(learning.University) != null)
            {
                AddError("The University has already been taken.");
                return ValidationResult;
            }

            //learning.AddDomainEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _learningRepository.Add(learning);

            return await Commit(_learningRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateLearningCommand message, CancellationToken cancellationToken)
        {

            if (!message.IsValid()) return message.ValidationResult;

            var learning = new Models.Learning(message.Id,message.University);
            var existingLearning = await _learningRepository.GetById(learning.Id);

            if (existingLearning == null)
            {
                AddError("The learningId does not exist.");
                return ValidationResult;
            }

            if (existingLearning != null && existingLearning.Id != learning.Id)
            {
                if (!existingLearning.Equals(learning))
                {
                    AddError("The university has already been taken.");
                    return ValidationResult;
                }
            }

            //customer.AddDomainEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _learningRepository.Update(learning);

            return await Commit(_learningRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(RemoveLearningCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _learningRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            //customer.AddDomainEvent(new CustomerRemovedEvent(message.Id));

            _learningRepository.Remove(customer);

            return await Commit(_learningRepository.UnitOfWork);
        }
    }
}
