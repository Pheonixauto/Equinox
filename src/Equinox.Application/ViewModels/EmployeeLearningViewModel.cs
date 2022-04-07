using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.ViewModels
{
    public class EmployeeLearningViewModel
    {

        [Key ,Column(Order =0)]
        public Guid EmployeeId { get; set; }
        [Key, Column(Order = 1)]
        public Guid LearningId { get; set; }

        public string Major { get; set; }
        public string Qualification { get; set; }
    }
}
