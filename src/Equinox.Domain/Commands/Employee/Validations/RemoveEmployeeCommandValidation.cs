using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Employee.Validations
{
    public class RemoveEmployeeCommandValidation : EmployeeValidation<RemoveEmployeeCommand>
    {
        public RemoveEmployeeCommandValidation()
        {
            ValidateId();
        }

    }
}
