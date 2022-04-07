using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Skill
{
    public class UpdateSkillCommand : SkillCommand
    {
        public UpdateSkillCommand(string name)
        {
            Name = name;
        }
    }
}
