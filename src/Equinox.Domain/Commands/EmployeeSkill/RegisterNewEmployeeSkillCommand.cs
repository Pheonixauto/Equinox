using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.EmployeeSkill
{
    public class RegisterNewEmployeeSkillCommand : EmployeeSkillCommand
    {
        public RegisterNewEmployeeSkillCommand(Guid employeeId, Guid skillId, string rating)
        {
            EmployeeId= employeeId;
            SkillId= skillId;
            Rating= rating;
        }
    }
}
