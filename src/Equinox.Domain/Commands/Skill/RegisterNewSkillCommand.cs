using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Skill
{
    public class RegisterNewSkillCommand : SkillCommand
    {
        public RegisterNewSkillCommand( Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
