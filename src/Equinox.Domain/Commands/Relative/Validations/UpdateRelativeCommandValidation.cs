using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Relative.Validations
{
    public class UpdateRelativeCommandValidation : RelativeValidation<UpdateRelativeCommand>
    {
        public UpdateRelativeCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
