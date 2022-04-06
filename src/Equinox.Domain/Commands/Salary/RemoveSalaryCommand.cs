using Equinox.Domain.Commands.Salary.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Salary
{
    public class RemoveSalaryCommand : SalaryCommand
    {
        public RemoveSalaryCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveSalaryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
