using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    [Authorize]
    public class SkillController : ApiController
    {
        private readonly ISkillAppService _skillAppService;
        public SkillController(ISkillAppService skillAppService)
        {
            _skillAppService = skillAppService;
        }
        [AllowAnonymous]
        [HttpGet("skill-management")]
        public async Task<IEnumerable<SkillViewModel>> Get()
        {
            return await _skillAppService.GetAll();
        }
        //[CustomAuthorize("Customers", "Write")]
        [AllowAnonymous]

        [HttpPost("skill-management")]
        public async Task<IActionResult> Post([FromBody] SkillViewModel skillViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _skillAppService.Register(skillViewModel));
        }
        [AllowAnonymous]

        [HttpPut("skill-management")]
        public async Task<IActionResult> Put([FromBody] SkillViewModel skillViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _skillAppService.Update(skillViewModel));
        }
        [AllowAnonymous]
        [HttpDelete("skill-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _skillAppService.Remove(id));
        }
    }
}
