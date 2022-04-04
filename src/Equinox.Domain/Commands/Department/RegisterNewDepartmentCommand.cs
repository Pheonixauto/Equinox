using Equinox.Domain.Commands.Department.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Department
{
    public class RegisterNewDepartmentCommand : DepartmentCommand
    {
        public RegisterNewDepartmentCommand(string name)
        {
            Name = name;
   
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewDepartmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
