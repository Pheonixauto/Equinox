using Equinox.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface IEmployeeLearningAppService : IDisposable
    {
        Task<IEnumerable<EmployeeLearningViewModel>> GetAll();
        Task<EmployeeLearningViewModel> GetById(Guid employeeId, Guid learningId);
        Task<ValidationResult> Register(EmployeeLearningViewModel employeeLearningViewModel);
        Task<ValidationResult> Update(EmployeeLearningViewModel employeeLearningViewModel);
        Task<ValidationResult> Remove(Guid employeeId, Guid learningId);
    }
}
