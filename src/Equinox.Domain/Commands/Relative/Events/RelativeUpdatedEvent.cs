using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Relative.Events
{
    public class RelativeUpdatedEvent : Event
    {
        public RelativeUpdatedEvent(Guid id, string name, string email, DateTime birthDate, Guid employeeId)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            EmployeeId = employeeId;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
        public Guid EmployeeId { get; private set; }
    }
}
