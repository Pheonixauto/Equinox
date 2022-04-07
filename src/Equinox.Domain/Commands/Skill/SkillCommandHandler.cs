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

namespace Equinox.Domain.Commands.Skill
{
    public class SkillCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewSkillCommand, ValidationResult>,
        IRequestHandler<UpdateSkillCommand, ValidationResult>,
        IRequestHandler<RemoveSkillCommand,ValidationResult>
    {
        private readonly ISkillRepository _skillRepository;
        public SkillCommandHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<ValidationResult> Handle(RegisterNewSkillCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var skill = new Models.Skill(request.Id, request.Name);
            _skillRepository.Add(skill);
            return await Commit(_skillRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var skill = new Models.Skill(request.Id, request.Name);
            _skillRepository.Update(skill);
            return await Commit(_skillRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(RemoveSkillCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var skill = await _skillRepository.GetById(request.Id);
            if(skill is null)
            {
                AddError("not exist");
                return ValidationResult;
            }
            _skillRepository.Remove(skill);
            return await Commit(_skillRepository.UnitOfWork);

        }
        public void Dispose()
        {
            _skillRepository.Dispose();
        }
    }
}
