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

namespace Equinox.Domain.Commands.EmployeeLearning
{
    public class EmployeeLearningCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewEmployeeLearningCommand, ValidationResult>,
        IRequestHandler<UpdateEmployeeLearningCommand, ValidationResult>,
        IRequestHandler<RemoveEmployeeLearningCommand, ValidationResult>
    {
        private readonly IEmployeeLearningRepository _employeeLearningRepository;
        public EmployeeLearningCommandHandler(IEmployeeLearningRepository employeeLearningRepository)
        {
            _employeeLearningRepository = employeeLearningRepository;
        }
        public async Task<ValidationResult> Handle(RegisterNewEmployeeLearningCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var employeeLearning = new Models.EmployeeLearning(request.EmployeeId, request.LearningId, request.Major, request.Qualification);
            _employeeLearningRepository.Add(employeeLearning);
            return await Commit(_employeeLearningRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateEmployeeLearningCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var employeeLearning = new Models.EmployeeLearning(request.EmployeeId, request.LearningId, request.Major, request.Qualification);
            _employeeLearningRepository.Update(employeeLearning);
            return await Commit(_employeeLearningRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveEmployeeLearningCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var employeeLearning = await _employeeLearningRepository.GetById(request.EmployeeId, request.LearningId);
            if (employeeLearning == null)
            {
                AddError("err");
                return ValidationResult;
            }
            _employeeLearningRepository.Remove(employeeLearning);
            return await Commit(_employeeLearningRepository.UnitOfWork);
        }
    }
}
