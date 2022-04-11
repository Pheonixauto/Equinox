using Atlassian.Jira;
using Jira.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.Application.Interface
{
    public interface IHttpClientJiraService
    {
        Task<JiraUser> Getmyselfcompanyjira(string account, string password, string member);
        Task<dynamic> UpdateUser(string account, string password, string key, UpdateUserJira updateUserJira);
        Task<Dictionary<string, string>> GetAllKeysProjects(string account, string password);
        Task<List<string>> CheckInforProjectByUser(string account,
                                                  string password,
                                                  string member,
                                                  Dictionary<string, string> keyProject);
    }
}
