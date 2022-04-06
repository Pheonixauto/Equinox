using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{    
    public class SalaryController : ApiController
    {
        private readonly ISalaryAppService _salaryAppService;
        public SalaryController(ISalaryAppService salaryAppService)
        {
            _salaryAppService = salaryAppService;
        }
        [AllowAnonymous]
        [HttpGet("salary-management")]
        public async Task<IEnumerable<SalaryViewModel>> Get()
        {
            return await _salaryAppService.GetAll();
        }
        [AllowAnonymous]
        [HttpGet("salary-management/{id:guid}")]
        public async Task<SalaryViewModel> Get(Guid id)
        {
            return await _salaryAppService.GetById(id);
        }
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPost("salary-management")]
        public async Task<IActionResult> Post([FromBody] SalaryViewModel salaryViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _salaryAppService.Register(salaryViewModel));
        }
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPut("salary-management")]
        public async Task<IActionResult> Put([FromBody] SalaryViewModel salaryViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _salaryAppService.Update(salaryViewModel));
        }
        [AllowAnonymous]

        //[CustomAuthorize("Employee", "Remove")]
        [HttpDelete("salary-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _salaryAppService.Remove(id));
        }
    }
}
