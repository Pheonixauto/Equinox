using Equinox.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface ISalaryAppService : IDisposable
    {
        Task<IEnumerable<SalaryViewModel>> GetAll();
        Task<SalaryViewModel> GetById(Guid id);
        Task<ValidationResult>Register(SalaryViewModel salaryViewModel);
        Task<ValidationResult> Update(SalaryViewModel salaryViewModel);
        Task<ValidationResult> Remove(Guid id);

    }
}
