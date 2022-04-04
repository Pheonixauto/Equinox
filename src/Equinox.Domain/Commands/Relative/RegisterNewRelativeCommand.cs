using Equinox.Domain.Commands.Relative.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Relative
{
    public class RegisterNewRelativeCommand : RelativeCommand
    {
        public RegisterNewRelativeCommand(string name, string email, DateTime birthDate, Guid employeeId)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            EmployeeId = employeeId;

        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewRelativeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
