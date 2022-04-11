using EmailService;
using Equinox.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly IHandleFilePDFService _handleFilePDFService;
        private readonly IEmployeeAppService _employeeAppService;
        public EmailController(IEmailSender emailSender, IHandleFilePDFService handleFilePDFService, IEmployeeAppService employeeAppService)
        {
            _emailSender = emailSender;
            _handleFilePDFService = handleFilePDFService;
            _employeeAppService = employeeAppService;
        }
        [HttpGet]
        public async Task<IActionResult> get([FromQuery] DateTime date)
        {
            var result = await _employeeAppService.GetEmailAndId();

            foreach (var item in result)
            {
                var file = await _handleFilePDFService.GetFilePdf(item.Id, date);
                var message = new Message(new string[] { item.Email! }, "test async", "from asp.net core", file);
                await _emailSender.SendEmailAsync(message);

            }

            //var file = await _handleFilePdfService.GetFilePdf(employeeid);
            //var message = new Message(new string[] { a }, "test async", "from asp.net core", file);
            //await _emailSender.SendEmailAsync(message);
            return Ok();
        }
    }
}
