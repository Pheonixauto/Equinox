using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Department.Events
{
    public class DepartmentUpdatedEvent : Event
    {
        public DepartmentUpdatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

    }
}
