using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Salary.Events
{
    public class SalaryRegisteredEvent: Event
    {
        public SalaryRegisteredEvent(Guid id, DateTime dateTime, decimal basicSalary, decimal tax, Guid employeeId)
        {
            Id = id;
            DateTime = dateTime;
            BasicSalary = basicSalary;
            Tax = tax;
            EmployeeId = employeeId;
            AggregateId = id;
        }
        public Guid Id { get; protected set; }
        public DateTime DateTime { get; protected set; }
        public decimal BasicSalary { get; protected set; }
        public decimal Tax { get; protected set; }
        public Guid EmployeeId { get; protected set; }
    }
}
