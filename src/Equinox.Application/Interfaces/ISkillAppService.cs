using Equinox.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface ISkillAppService : IDisposable
    {
        Task<IEnumerable<SkillViewModel>> GetAll();
        Task<ValidationResult> Register(SkillViewModel skillViewModel);
        Task<ValidationResult> Update(SkillViewModel skillViewModel);
        Task<ValidationResult> Remove(Guid id);

    }
}
