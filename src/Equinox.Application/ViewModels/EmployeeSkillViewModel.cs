using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.ViewModels
{
    public class EmployeeSkillViewModel
    {
        public Guid EmployeeId { get;  set; }
        public Guid SkillId { get;  set; }
        public string Rating { get;  set; }
    }
}
