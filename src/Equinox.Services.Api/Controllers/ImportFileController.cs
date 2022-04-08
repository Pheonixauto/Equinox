using Equinox.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    public class ImportFileController : ControllerBase
    {
        private readonly IFileCsvService _fileCsvService;
        public ImportFileController(IFileCsvService fileCsvService)
        {
            _fileCsvService = fileCsvService;
        }
        [HttpPost("UpLoadFile")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpLoadFileIntoDataBase(IFormFile file)
        {
            var result = await _fileCsvService.AddEmployeeByCsv(file);
            return Ok(result);
        }
    }
}
