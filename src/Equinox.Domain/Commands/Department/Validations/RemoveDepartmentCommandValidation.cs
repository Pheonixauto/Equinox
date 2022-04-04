using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Department.Validations
{
    public class RemoveDepartmentCommandValidation : DepartmentValidation<RemoveDepartmentCommand>
    {
        public RemoveDepartmentCommandValidation()
        {
            ValidateId();

        }
    }
}
