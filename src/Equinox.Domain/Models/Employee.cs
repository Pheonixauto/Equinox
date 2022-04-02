using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Models
{
    public class Employee : Entity, IAggregateRoot
    {
        public Employee(Guid id, string name, string email, DateTime birthDate, Guid departmentId)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            DepartmentId = departmentId;
        }

        // Empty constructor for EF
        protected Employee() { }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Guid? DepartmentId { get; private set; }
        public Department Department { get; private set; }
    }
}
