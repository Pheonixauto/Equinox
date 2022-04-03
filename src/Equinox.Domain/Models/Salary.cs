using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Models
{
    public class Salary : Entity, IAggregateRoot
    {
        public Salary(Guid id, DateTime dateTime , decimal basicSalary, decimal tax, Guid employeeId)
        {
            Id = id;
            DateTime = dateTime;
            BasicSalary = basicSalary;
            Tax = tax;
            EmployeeId = employeeId;
        }
        // Empty constructor for EF
        protected Salary() { }
        public DateTime DateTime { get; private set; }
        public decimal BasicSalary { get; private set; }
        public decimal Tax { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
    }
}
