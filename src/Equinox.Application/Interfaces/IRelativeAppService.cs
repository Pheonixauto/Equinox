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
        Task<ValidationResult> Register(RelativeViewModel relativeViewModel);

    }
}
