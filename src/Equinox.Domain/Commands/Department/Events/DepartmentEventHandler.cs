using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Department.Events
{
    public class DepartmentEventHandler : INotificationHandler<DepartmentRegisteredEvent>,
                                          INotificationHandler<DepartmentUpdatedEvent>,
                                           INotificationHandler<DepartmentRemovedEvent>
    {
        public Task Handle(DepartmentRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DepartmentUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DepartmentRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
