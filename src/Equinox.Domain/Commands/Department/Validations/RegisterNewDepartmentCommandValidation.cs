using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Department.Validations
{
    public class RegisterNewDepartmentCommandValidation : DepartmentValidation<RegisterNewDepartmentCommand>
    {
        public RegisterNewDepartmentCommandValidation()
        {
            ValidateName();
        }
    }
}
