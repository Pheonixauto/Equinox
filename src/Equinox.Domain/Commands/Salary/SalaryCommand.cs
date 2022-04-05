using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Salary
{
    public class SalaryCommand : Command
    {
        public Guid Id { get; protected set; }
        public DateTime DateTime { get; protected set; }
        public decimal BasicSalary { get; protected set; }
        public decimal Tax { get; protected set; }
        public Guid EmployeeId { get; protected set; }
    }
}
