using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    [Authorize]
    public class RelativeController : ApiController
    {
        private readonly IRelativeAppService _relativeAppService;
        public RelativeController(IRelativeAppService relativeAppService)
        {
            _relativeAppService = relativeAppService;
        }
        [AllowAnonymous]
        [HttpGet("relative-management")]
        public async Task<IEnumerable<RelativeViewModel>> Get()
        {
            return await _relativeAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("relative-management/{id:guid}")]
        public async Task<RelativeViewModel> Get(Guid id)
        {
            return await _relativeAppService.GetById(id);
        }
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPost("relative-management")]
        public async Task<IActionResult> Post([FromBody] RelativeViewModel relativeAppService)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _relativeAppService.Register(relativeAppService));
        }
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPut("relative-management")]
        public async Task<IActionResult> Put([FromBody] RelativeViewModel relativeAppService)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _relativeAppService.Update(relativeAppService));
        }
        [AllowAnonymous]
        //[CustomAuthorize("Employee", "Remove")]
        [HttpDelete("relative-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _relativeAppService.Remove(id));
        }
    }
}
