using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.DTO
{
    public class ImportEmployeeDTO
    {
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("Name")]
        public string Name { get;  set; }
        [Column("Email")]
        public string Email { get;  set; }
        [Column("BirthDate")]
        public DateTime BirthDate { get;  set; }
        [Column("DepartmentId")]
        public Guid? DepartmentId { get;  set; }

    }
}
