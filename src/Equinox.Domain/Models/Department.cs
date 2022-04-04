using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Models
{
    public class Department : Entity, IAggregateRoot
    {
        public Department(Guid id, string name)
        {
            Id = id;
            Name = name;
         

        }

        // Empty constructor for EF
        public Department() { }
        public string Name { get;  set; }
        public ICollection<Employee> Employees { get; private set; }

    }
}
