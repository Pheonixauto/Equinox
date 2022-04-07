using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.EmployeeSkill
{
    public class RemoveEmployeeSkillCommand : EmployeeSkillCommand
    {
        public RemoveEmployeeSkillCommand(Guid employeeId, Guid skillId)
        {
            EmployeeId = employeeId;
            SkillId = skillId;
        }
    }
}
