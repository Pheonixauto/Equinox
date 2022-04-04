using AutoMapper;
using Equinox.Application.EventSourcedNormalizers.Employee;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Employee;
using Equinox.Domain.Interfaces;
using Equinox.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Services
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;
        public EmployeeAppService(IMapper mapper,
                                 IEmployeeRepository employeeRepository,
                                 IMediatorHandler mediator,
                                 IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeeRepository.GetAll());

        }

        public async Task<IList<EmployeeHistoryData>> GetAllHistory(Guid id)
        {
            return EmployeeHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));

        }

        public async Task<EmployeeViewModel> GetById(Guid id)
        {
            var employee = await _employeeRepository.GetById(id);
            return _mapper.Map<EmployeeViewModel>(employee);
        }

        public async Task<ValidationResult> Register(EmployeeViewModel employeeViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewEmployeeCommand>(employeeViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveEmployeeCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(EmployeeViewModel employeeViewModel)
        {
            var updateCommand = _mapper.Map<UpdateEmployeeCommand>(employeeViewModel);
            return await _mediator.SendCommand(updateCommand);
        }
    }
}
