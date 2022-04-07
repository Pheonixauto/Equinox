using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.EmployeeLearning;
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
    public class EmployeeLearningAppService : IEmployeeLearningAppService
    {
        private readonly IEmployeeLearningRepository _employeeLearningRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        public EmployeeLearningAppService(IEmployeeLearningRepository employeeLearningRepository,
            IMapper mapper, IMediatorHandler mediator
            )
        {
            _employeeLearningRepository = employeeLearningRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<EmployeeLearningViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeLearningViewModel>>(await _employeeLearningRepository.GetAll());
        }

        public async Task<EmployeeLearningViewModel> GetById(Guid employeeId, Guid learningId)
        {
            return _mapper.Map<EmployeeLearningViewModel>(await _employeeLearningRepository.GetById(employeeId,learningId));
        }

        public async Task<ValidationResult> Register(EmployeeLearningViewModel employeeLearningViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewEmployeeLearningCommand>(employeeLearningViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid employeeId, Guid learningId)
        {
            var removeCommand = new RemoveEmployeeLearningCommand(employeeId, learningId);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(EmployeeLearningViewModel employeeLearningViewModel)
        {
            var updateCommand = _mapper.Map<UpdateEmployeeLearningCommand>(employeeLearningViewModel);
           return await _mediator.SendCommand(updateCommand);
        }
    }
}
