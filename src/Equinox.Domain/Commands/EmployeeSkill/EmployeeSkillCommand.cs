using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.EmployeeSkill
{
    public abstract class EmployeeSkillCommand : Command
    {
        public Guid EmployeeId { get; protected set; }
        public Guid SkillId { get; protected set; }
        public string Rating { get; protected set; }
    }
}
