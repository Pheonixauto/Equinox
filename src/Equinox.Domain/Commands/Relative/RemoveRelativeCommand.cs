using Equinox.Domain.Commands.Relative.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Relative
{
    public class RemoveRelativeCommand : RelativeCommand
    {
        public RemoveRelativeCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveRelativeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
