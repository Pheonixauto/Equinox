using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.EmployeeSkill
{
    public class UpdateEmployeeSkillCommand : EmployeeSkillCommand
    {
        public UpdateEmployeeSkillCommand(Guid employeeId, Guid skillId,string rating)
        {
            Rating = rating;
            EmployeeId = employeeId;
            SkillId = skillId;
        }
    }
}
