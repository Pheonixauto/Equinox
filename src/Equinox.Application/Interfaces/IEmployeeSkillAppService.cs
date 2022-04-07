using Equinox.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface IEmployeeSkillAppService : IDisposable
    {
        Task<IEnumerable<EmployeeSkillViewModel>> GetAll();
        Task<ValidationResult> Register(EmployeeSkillViewModel employeeSkillViewModel);
        Task<ValidationResult> Update(EmployeeSkillViewModel employeeSkillViewModel);
        Task<ValidationResult> Remove(Guid employeeId, Guid skillId);
    }
}
