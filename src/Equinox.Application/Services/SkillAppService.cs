using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Skill;
using Equinox.Domain.Interfaces;
using FluentValidation.Results;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Services
{
    public class SkillAppService : ISkillAppService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public SkillAppService(ISkillRepository skillRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<SkillViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<SkillViewModel>>(await _skillRepository.GetAll());
        }

        public async Task<ValidationResult> Register(SkillViewModel skillViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewSkillCommand>(skillViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveSkillCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(SkillViewModel skillViewModel)
        {
            var updateCommand = _mapper.Map<UpdateSkillCommand>(skillViewModel);
            return await _mediator.SendCommand(updateCommand);
        }
    }
}
