using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Salary;
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
    public class SalaryAppService : ISalaryAppService
    {
        private readonly IMapper _mapper;
        private readonly ISalaryRepository _salaryRepository;
        private readonly IMediatorHandler _mediator;

        public SalaryAppService(IMapper mapper, ISalaryRepository salaryRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _salaryRepository = salaryRepository;
            _mediator = mediator;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<SalaryViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<SalaryViewModel>>(await _salaryRepository.GetAll());

        }

        public async Task<SalaryViewModel> GetById(Guid id)
        {
            return _mapper.Map<SalaryViewModel>(await _salaryRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(SalaryViewModel salaryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewSalaryCommand>(salaryViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveSalaryCommand(id);
            return await _mediator.SendCommand(removeCommand);

        }

        public async Task<ValidationResult> Update(SalaryViewModel salaryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateSalaryCommand>(salaryViewModel);
            return await _mediator.SendCommand(updateCommand);
        }
    }
}
