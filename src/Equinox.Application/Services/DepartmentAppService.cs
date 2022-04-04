using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Department;
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
    public class DepartmentAppService : IDepartmentAppService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMediatorHandler _mediator;
        public DepartmentAppService(IDepartmentRepository departmentRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<DepartmentViewModel>>(await _departmentRepository.GetAll());
        }

        public async Task<DepartmentViewModel> GetById(Guid id)
        {
            return _mapper.Map<DepartmentViewModel>(await _departmentRepository.GetById(id));

        }

        public async Task<ValidationResult> Register(DepartmentViewModel departmentViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewDepartmentCommand>(departmentViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveDepartmentCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(DepartmentViewModel departmentViewModel)
        {
            var updateCommand = _mapper.Map<UpdateDepartmentCommand>(departmentViewModel);
            return await _mediator.SendCommand(updateCommand);
        }
    }
}
