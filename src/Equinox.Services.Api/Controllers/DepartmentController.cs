using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    [Authorize]
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentAppService _departmentAppService;
        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }
        [AllowAnonymous]
        [HttpGet("department-management/{id:guid}")]
        public async Task<DepartmentViewModel> Get(Guid id)
        {
            return await _departmentAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("department-management")]
        public async Task<IEnumerable<DepartmentViewModel>> Get()
        {
            return await _departmentAppService.GetAll();
        }
        [AllowAnonymous]

        [HttpPost("department-management")]
        public async Task<IActionResult> Post([FromBody] DepartmentViewModel departmentViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _departmentAppService.Register(departmentViewModel));
        }
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPut("department-management")]
        public async Task<IActionResult> Put([FromBody] DepartmentViewModel departmentViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _departmentAppService.Update(departmentViewModel));
        }
        [AllowAnonymous]

        //[CustomAuthorize("Employee", "Remove")]
        [HttpDelete("department-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _departmentAppService.Remove(id));
        }
    }
}
