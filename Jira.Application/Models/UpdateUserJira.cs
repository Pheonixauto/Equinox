using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.Application.Models
{
    public class UpdateUserJira
    {
        public string displayName { get; set; } = string.Empty;
        public bool active { get; set; }
    }
}
