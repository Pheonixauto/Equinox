using Equinox.Domain.Commands.Department.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Department
{
    public class RemoveDepartmentCommand : DepartmentCommand
    {
        public RemoveDepartmentCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDepartmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
