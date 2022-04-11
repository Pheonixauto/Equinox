using Equinox.Application.EventSourcedNormalizers.Employee;
using Equinox.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface IEmployeeAppService : IDisposable
    {
        Task<EmployeeViewModel> GetById(Guid id);
        Task<IEnumerable<EmployeeViewModel>> GetAll();

        Task<IEnumerable<EmployeeViewModel>> GetEmailAndId();

        Task<ValidationResult> Register(EmployeeViewModel employeeViewModel);
        Task<ValidationResult> Update(EmployeeViewModel employeeViewModel);
        Task<ValidationResult> Remove(Guid id);

        Task<IList<EmployeeHistoryData>> GetAllHistory(Guid id);

    }
}
