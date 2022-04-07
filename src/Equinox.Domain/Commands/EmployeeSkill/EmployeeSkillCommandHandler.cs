using Equinox.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.EmployeeSkill
{
    public class EmployeeSkillCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewEmployeeSkillCommand, ValidationResult>,
        IRequestHandler<UpdateEmployeeSkillCommand, ValidationResult>,
        IRequestHandler<RemoveEmployeeSkillCommand, ValidationResult>
    {
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        public EmployeeSkillCommandHandler(IEmployeeSkillRepository employeeSkillRepository)
        {
            _employeeSkillRepository = employeeSkillRepository;
        }
        public async Task<ValidationResult> Handle(RegisterNewEmployeeSkillCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var employeeSkill = new Models.EmployeeSkill(request.EmployeeId, request.SkillId, request.Rating);
            _employeeSkillRepository.Add(employeeSkill);
            return await Commit(_employeeSkillRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateEmployeeSkillCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var employeeSkill = new Models.EmployeeSkill(request.EmployeeId, request.SkillId, request.Rating);
            _employeeSkillRepository.Update(employeeSkill);
            return await Commit(_employeeSkillRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(RemoveEmployeeSkillCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var employeeSkill = await _employeeSkillRepository.GetById(request.EmployeeId, request.SkillId);
            _employeeSkillRepository.Remove(employeeSkill);
            return await Commit(_employeeSkillRepository.UnitOfWork);

        }
    }
}
