using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.EmployeeLearning
{
    public abstract class EmployeeLearningCommand : Command
    {
        public Guid EmployeeId { get; protected set; }
        public Guid LearningId { get; protected set; }
        public string Major { get; protected set; }
        public string Qualification { get; protected set; }
    }
}
