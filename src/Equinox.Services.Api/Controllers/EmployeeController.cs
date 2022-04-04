using Equinox.Application.EventSourcedNormalizers.Employee;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    [Authorize]

    public class EmployeeController : ApiController
    {
        private readonly IEmployeeAppService _employeeAppService;
        public EmployeeController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }
        [AllowAnonymous]
        [HttpGet("employee-management")]
        public async Task<IEnumerable<EmployeeViewModel>> Get()
        {
            return await _employeeAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("employee-management/{id:guid}")]
        public async Task<EmployeeViewModel> Get(Guid id)
        {
            return await _employeeAppService.GetById(id);
        }
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPost("employee-management")]
        public async Task<IActionResult> Post([FromBody] EmployeeViewModel employeeViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _employeeAppService.Register(employeeViewModel));
        }
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPut("employee-management")]
        public async Task<IActionResult> Put([FromBody] EmployeeViewModel employeeViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _employeeAppService.Update(employeeViewModel));
        }
        [AllowAnonymous]

        //[CustomAuthorize("Employee", "Remove")]
        [HttpDelete("employee-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _employeeAppService.Remove(id));
        }
        [AllowAnonymous]
        [HttpGet("employee-management/history/{id:guid}")]
        public async Task<IList<EmployeeHistoryData>> History(Guid id)
        {
            return await _employeeAppService.GetAllHistory(id);
        }
    }
}
