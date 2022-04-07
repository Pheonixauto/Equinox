using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.EmployeeLearning
{
    public class RemoveEmployeeLearningCommand : EmployeeLearningCommand
    {
        public RemoveEmployeeLearningCommand(Guid employeeId, Guid learningId)
        {
            EmployeeId = employeeId;
            LearningId = learningId;
        }
    }
}
