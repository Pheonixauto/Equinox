using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Salary.Events
{
    public class SalaryEventHandler : INotificationHandler<SalaryRegisteredEvent>
    {
        public Task Handle(SalaryRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
