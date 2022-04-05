using Equinox.Domain.Commands.Relative.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Relative
{
    public class UpdateRelativeCommand : RelativeCommand
    {
        public UpdateRelativeCommand(Guid id, string name, string email, DateTime birthDate,Guid employeeId)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            EmployeeId = employeeId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateRelativeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
