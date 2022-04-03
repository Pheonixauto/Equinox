using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Models
{
    public class EmployeeSkill : IAggregateRoot
    {
        public EmployeeSkill(Guid employeeId, Guid skillId, string rating)
        {
            EmployeeId = employeeId;
            SkillId = skillId;
            Rating = rating;
        }
        protected EmployeeSkill() { }

        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
        public Guid SkillId { get; private set; }
        public Skill Skill { get; private set; }
        public string Rating { get; private set; }
    }

}
