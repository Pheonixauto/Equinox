using Equinox.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface IRelativeAppService : IDisposable
    {
        Task<IEnumerable<RelativeViewModel>> GetAll();
        Task<RelativeViewModel> GetById(Guid id);
        Task<ValidationResult> Register(RelativeViewModel relativeViewModel);
        Task<ValidationResult> Update(RelativeViewModel relativeViewModel);

        Task<ValidationResult> Remove(Guid id);

    }
}
