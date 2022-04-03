using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Models
{
    public class Relative : Entity, IAggregateRoot
    {
        public Relative(Guid id, string name, string email, DateTime birthDate, Guid employeeId)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            EmployeeId = employeeId;
        }

        // Empty constructor for EF
        protected Relative() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
    }
}
