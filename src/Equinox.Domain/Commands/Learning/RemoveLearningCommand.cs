using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Learning
{
    public class RemoveLearningCommand : LearningCommand
    {
        public RemoveLearningCommand(Guid id)
        {
            Id = id;
        }
    }
}
