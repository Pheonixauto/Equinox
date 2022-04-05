using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.ViewModels
{
    public class SalaryViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The DateTime is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("DateTime")]
        public DateTime DateTime { get; set; }
        public decimal BasicSalary { get;set; }
        public decimal Tax { get; set; }
        public Guid EmployeeId { get;  set; }
    }
}
