using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Employee.Validations
{
    public class UpdateEmployeeCommandValidation : EmployeeValidation<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
