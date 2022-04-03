using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Models
{
    public class Skill : Entity, IAggregateRoot
    {
        public Skill(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        protected Skill() { }
        public string Name { get; private set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; private set; }
    }
}
