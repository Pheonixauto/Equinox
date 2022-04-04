using Equinox.Domain.Commands.Department.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Department
{
    public class UpdateDepartmentCommand : DepartmentCommand
    {
        public UpdateDepartmentCommand(Guid id, string name)
        {
            Id = id;
            Name = name;

        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateDepartmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
