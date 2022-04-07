using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.EmployeeSkill;
using Equinox.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Services
{
    public class EmployeeSkillAppService : IEmployeeSkillAppService
    {
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;
        public EmployeeSkillAppService(IEmployeeSkillRepository employeeSkillRepository, IMapper mapper, IMediatorHandler mediatorHandler)
        {
            _employeeSkillRepository = employeeSkillRepository;
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<EmployeeSkillViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeSkillViewModel>>(await _employeeSkillRepository.GetAll());
        }

        public async Task<ValidationResult> Register(EmployeeSkillViewModel employeeSkillViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewEmployeeSkillCommand>(employeeSkillViewModel);
            return await _mediatorHandler.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid employeeId, Guid skillId)
        {
            var removeCommand = new RemoveEmployeeSkillCommand(employeeId, skillId);
            return await _mediatorHandler.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(EmployeeSkillViewModel employeeSkillViewModel)
        {
            var updateCommand = _mapper.Map<UpdateEmployeeSkillCommand>(employeeSkillViewModel);
            return await _mediatorHandler.SendCommand(updateCommand);
        }
    }
}
