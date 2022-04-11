using Jira.Application.Interface;
using Jira.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Equinox.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientJiraController : ControllerBase
    {
        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientJiraService _httpClientJiraService;
        public HttpClientJiraController( IHttpClientJiraService httpClientJiraService)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClientJiraService = httpClientJiraService;
        }
        [HttpGet("getmyselfcompany")]
        public async Task<IActionResult> getmyselfcompany(string account,
                                                          string password, string member)
        {
            var re = await _httpClientJiraService.Getmyselfcompanyjira(account, password, member);
            return Ok(re);
        }
        [HttpGet("GetInforProjectByUser")]
        public async Task<IActionResult> GetInforProjectByUser(string account,
                                                               string password, string member)
        {
            var re = await _httpClientJiraService.GetAllKeysProjects(account, password);

            var result = await _httpClientJiraService.CheckInforProjectByUser(account, password,
                                                                      member, re);

            return Ok(result);
        }
        [HttpPut("IsActiveUser")]
        public async Task<IActionResult> IsactiveUser(string account,
                                                      string password,
                                                      string userKey,
                                                      UpdateUserJira updateUserJira)
        {
            var result = await _httpClientJiraService.UpdateUser(account, password, userKey, updateUserJira);
            return Ok(result);
        }
    }
}
