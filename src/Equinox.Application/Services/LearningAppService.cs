using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Learning;
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
    public class LearningAppService : ILearningAppService
    {
        private readonly IMapper _mapper;
        private readonly ILearningRepository _learningRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public LearningAppService(IMapper mapper,
                                  ILearningRepository learningRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _learningRepository = learningRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);

        }

        public async Task<LearningViewModel> GetById(Guid id)
        {
            return _mapper.Map<LearningViewModel>(await _learningRepository.GetById(id));
        }

        public async Task<IEnumerable<LearningViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<LearningViewModel>>(await _learningRepository.GetAll());
        }

        public async Task<ValidationResult> Create(LearningViewModel learningViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewLearningCommand>(learningViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(LearningViewModel learningViewModel)
        {
            var updateCommand = _mapper.Map<UpdateLearningCommand>(learningViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveLearningCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }
    }
}
