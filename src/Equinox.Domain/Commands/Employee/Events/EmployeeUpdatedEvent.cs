using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Employee.Events
{
    public class EmployeeUpdatedEvent : Event
    {
        public EmployeeUpdatedEvent(Guid id, string name, string email, DateTime birthDate, Guid? departmentId)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            DepartmentId = departmentId;
            AggregateId = id;

        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
        public Guid? DepartmentId { get; private set; }
    }
}
