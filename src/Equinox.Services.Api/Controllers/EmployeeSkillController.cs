using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    [Authorize]
    public class EmployeeSkillController : ApiController
    {
        private readonly IEmployeeSkillAppService _employeeSkillAppService;
        public EmployeeSkillController(IEmployeeSkillAppService employeeSkillAppService)
        {
            _employeeSkillAppService = employeeSkillAppService;
        }
        [AllowAnonymous]
        [HttpGet("employeeskill-management")]
        public async Task<IEnumerable<EmployeeSkillViewModel>> Get()
        {
            return await _employeeSkillAppService.GetAll();
        }
        [AllowAnonymous]

        [HttpPost("employeeskill-management")]
        public async Task<IActionResult> Post([FromBody] EmployeeSkillViewModel employeeSkillAppService)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _employeeSkillAppService.Register(employeeSkillAppService));
        }
        [AllowAnonymous]

        [HttpPut("employeeskill-management")]
        public async Task<IActionResult> Put([FromBody] EmployeeSkillViewModel employeeSkillAppService)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _employeeSkillAppService.Update(employeeSkillAppService));
        }
        [AllowAnonymous]

        //[CustomAuthorize("Employee", "Remove")]
        [HttpDelete("employeeskill-management")]
        public async Task<IActionResult> Delete(Guid employeeId, Guid skillId)
        {
            return CustomResponse(await _employeeSkillAppService.Remove(employeeId,skillId));
        }
    }
}
