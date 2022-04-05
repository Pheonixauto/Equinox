using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Salary.Validations
{
    public class RegisterNewSalaryCommandValidation : SalaryValidation<RegisterNewSalaryCommand>
    {
        public RegisterNewSalaryCommandValidation()
        {
            ValidateId();
        }
    }
}
