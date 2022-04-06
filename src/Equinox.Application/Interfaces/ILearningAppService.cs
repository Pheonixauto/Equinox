using Equinox.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface ILearningAppService : IDisposable
    {
        Task<IEnumerable<LearningViewModel>> GetAll();
        Task<LearningViewModel> GetById(Guid id);
        Task<ValidationResult> Create(LearningViewModel learningViewModel);
        Task<ValidationResult> Update(LearningViewModel learningViewModel);
        Task<ValidationResult> Remove(Guid id);

    }
}
