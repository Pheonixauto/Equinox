using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Models
{
    public class Learning : Entity, IAggregateRoot
    {
        public Learning(Guid id, string university)
        {
            Id = id;
            University = university;
        }
        protected Learning() { }
        public string University { get; private set; }
        public ICollection<EmployeeLearning> EmployeeLearnings { get; private set; }
    }
}
