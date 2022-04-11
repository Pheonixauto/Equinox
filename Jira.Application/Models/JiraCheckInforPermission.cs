using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.Application.Models
{
    public class JiraCheckInforPermission
    {
        public string self { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public Dictionary<string, string> avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public bool deleted { get; set; }
        public string timeZone { get; set; }
        public string locale { get; set; }
    }
}
