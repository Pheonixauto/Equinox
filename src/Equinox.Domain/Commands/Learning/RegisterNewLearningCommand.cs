using Equinox.Domain.Commands.Learning.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Learning
{
    public class RegisterNewLearningCommand : LearningCommand
    {
        public RegisterNewLearningCommand(string university)
        {
            University = university;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewLearningCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
