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
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPost("employee-management")]
        public async Task<IActionResult> Post([FromBody] EmployeeViewModel employeeViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _employeeAppService.Register(employeeViewModel));
        }
    }
}
