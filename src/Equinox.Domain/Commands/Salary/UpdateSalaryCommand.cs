using Equinox.Domain.Commands.Salary.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Salary
{
    public class UpdateSalaryCommand : SalaryCommand
    {
        public UpdateSalaryCommand(Guid id, DateTime dateTime, decimal basicSalary, decimal tax, Guid employeeId)
        {
            Id = id;
            DateTime = dateTime;
            BasicSalary = basicSalary;
            Tax = tax;
            EmployeeId = employeeId;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateSalaryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
