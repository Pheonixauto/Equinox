using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    [Authorize]
    public class LearningController : ApiController
    {
        private readonly ILearningAppService _learningAppService;
        public LearningController(ILearningAppService learningAppService)
        {
            _learningAppService = learningAppService;
        }
        [AllowAnonymous]
        [HttpGet("learning-management")]
        public async Task<IEnumerable<LearningViewModel>> Get()
        {
            return await _learningAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("learning-management/{id:guid}")]
        public async Task<LearningViewModel> Get(Guid id)
        {
            return await _learningAppService.GetById(id);
        }
        [AllowAnonymous]

        [HttpPost("learning-management")]
        public async Task<IActionResult> Post([FromBody] LearningViewModel learningViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _learningAppService.Create(learningViewModel));
        }
        [AllowAnonymous]

        [HttpPut("learning-management")]
        public async Task<IActionResult> Put([FromBody] LearningViewModel learningViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _learningAppService.Update(learningViewModel));
        }
        [AllowAnonymous]

        //[CustomAuthorize("Employee", "Remove")]
        [HttpDelete("learning-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _learningAppService.Remove(id));
        }
    }
}
