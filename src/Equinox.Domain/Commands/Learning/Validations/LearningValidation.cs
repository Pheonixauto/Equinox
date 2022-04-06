using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Learning.Validations
{
    public abstract class LearningValidation<T> : AbstractValidator<T> where T : LearningCommand
    {
       
    }
}
