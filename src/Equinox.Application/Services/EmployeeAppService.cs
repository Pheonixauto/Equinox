using AutoMapper;
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

        public async Task<ValidationResult> Register(EmployeeViewModel employeeViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewEmployeeCommand>(employeeViewModel);
            return await _mediator.SendCommand(registerCommand);
        }
    }
}
