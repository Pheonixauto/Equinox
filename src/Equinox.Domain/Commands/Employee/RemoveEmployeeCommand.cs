using Equinox.Domain.Commands.Employee.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Employee
{
    public class RemoveEmployeeCommand : EmployeeCommand
    {
        public RemoveEmployeeCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveEmployeeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
