using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.EmployeeLearning
{
    public class RegisterNewEmployeeLearningCommand : EmployeeLearningCommand
    {
        public RegisterNewEmployeeLearningCommand(Guid employeeId, Guid learningId, string major, string qualification)
        {
            EmployeeId = employeeId;
            LearningId = learningId;
            Major = major;
            Qualification = qualification;
        }
    }
}
