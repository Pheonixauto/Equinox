using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.EventSourcedNormalizers.Employee
{
    public class EmployeeHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string DepartmentId { get; set; }
        public string Timestamp { get; set; }
        public string Who { get; set; }
    }
}
