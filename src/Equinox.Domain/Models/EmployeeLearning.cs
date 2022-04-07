using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Models
{
    public class EmployeeLearning :IAggregateRoot
    {
        public EmployeeLearning(Guid employeeId, Guid learningId, string major, string qualification)
        {
            EmployeeId = employeeId;
            LearningId = learningId;
            Major = major;
            Qualification = qualification;
        }
        protected EmployeeLearning() { }
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
        public Guid LearningId { get; private set; }
        public Learning Learning { get; private set; }
        public string Major { get; private set; }
        public string Qualification { get; private set; }
    }
}
