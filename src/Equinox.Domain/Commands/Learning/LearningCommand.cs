using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Learning
{
    public abstract class LearningCommand : Command
    {
        public Guid Id { get; protected set; }
        public string University { get;protected set; }

    }
}
