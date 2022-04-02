using Equinox.Domain.Commands.Employee.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Employee
{
    public class RegisterNewEmployeeCommand : EmployeeCommand
    {
        public RegisterNewEmployeeCommand(string name, string email, DateTime birthDate, Guid departmentId)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            DepartmentId = departmentId;

        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewEmployeeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
