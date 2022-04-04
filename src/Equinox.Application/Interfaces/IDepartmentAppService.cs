using Equinox.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface IDepartmentAppService : IDisposable
    {
        Task<DepartmentViewModel> GetById(Guid id);
        Task<IEnumerable<DepartmentViewModel>> GetAll();
        Task<ValidationResult> Register(DepartmentViewModel departmentViewModel);
        Task<ValidationResult> Update(DepartmentViewModel departmentViewModel);

        Task<ValidationResult> Remove(Guid id);

    }
}
