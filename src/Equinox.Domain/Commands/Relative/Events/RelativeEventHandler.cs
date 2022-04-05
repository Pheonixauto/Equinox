using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Relative.Events
{
    public class RelativeEventHandler : 
        INotificationHandler<RelativeRegisteredEvent>,
        INotificationHandler<RelativeUpdatedEvent>
    {
        public Task Handle(RelativeRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(RelativeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
    }
}
