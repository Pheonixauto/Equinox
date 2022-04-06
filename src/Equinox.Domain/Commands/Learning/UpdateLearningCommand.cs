using Equinox.Domain.Commands.Learning.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Learning
{
    public class UpdateLearningCommand : LearningCommand
    {
        public UpdateLearningCommand(Guid id, string university)
        {
            University = university;
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateLearningCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
