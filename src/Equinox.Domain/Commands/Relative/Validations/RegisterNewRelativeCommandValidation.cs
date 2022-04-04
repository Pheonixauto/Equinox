using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Relative.Validations
{
    public class RegisterNewRelativeCommandValidation : RelativeValidation<RegisterNewRelativeCommand>
    {
        public RegisterNewRelativeCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
