using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Relative;
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
    public class RelativeAppService : IRelativeAppService
    {
        private readonly IMapper _mapper;
        private readonly IRelativeRepository _relativeRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public RelativeAppService(IMapper mapper,
                                  IRelativeRepository relativeRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _relativeRepository = relativeRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<RelativeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<RelativeViewModel>>(await _relativeRepository.GetAll());
        }

        public async Task<RelativeViewModel> GetById(Guid id)
        {
            return _mapper.Map<RelativeViewModel>(await _relativeRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(RelativeViewModel relativeViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewRelativeCommand>(relativeViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveRelativeCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(RelativeViewModel relativeViewModel)
        {
            var updateCommand = _mapper.Map<UpdateRelativeCommand>(relativeViewModel);
            return await _mediator.SendCommand(updateCommand);
        }
    }
}
