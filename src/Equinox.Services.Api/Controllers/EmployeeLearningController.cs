using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    [Authorize]
    public class EmployeeLearningController : ApiController
    {
        private readonly IEmployeeLearningAppService _employeeLearningAppService;
        public EmployeeLearningController(IEmployeeLearningAppService employeeLearningAppService)
        {
            _employeeLearningAppService = employeeLearningAppService;
        }
        [AllowAnonymous]
        [HttpGet("employeelearning-management")]
        public async Task<IEnumerable<EmployeeLearningViewModel>> Get()
        {
            return await _employeeLearningAppService.GetAll();
        }
        [AllowAnonymous]
        [HttpGet("employeelearning-management/{id:guid}")]
        public async Task<EmployeeLearningViewModel> Get(Guid employeeId,Guid learningId)
        {
            return await _employeeLearningAppService.GetById(employeeId,learningId);
        }
        [AllowAnonymous]

        [HttpPost("employeelearning-management")]
        public async Task<IActionResult> Post([FromBody] EmployeeLearningViewModel employeeLearningViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _employeeLearningAppService.Register(employeeLearningViewModel));
        }
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPut("employeelearning-management")]
        public async Task<IActionResult> Put([FromBody] EmployeeLearningViewModel employeeLearningViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _employeeLearningAppService.Update(employeeLearningViewModel));
        }
        [AllowAnonymous]

        //[CustomAuthorize("Employee", "Remove")]
        [HttpDelete("employeelearning-management")]
        public async Task<IActionResult> Delete(Guid employeeId, Guid learningId)
        {
            return CustomResponse(await _employeeLearningAppService.Remove(employeeId,learningId));
        }
    }
}
