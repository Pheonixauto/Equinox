using Equinox.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Equinox.Services.Api.Controllers
{
    public class ExportFileController : ControllerBase
    {
        private readonly IEmployeeAppService _employeeAppService;
        public ExportFileController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }
        [HttpGet("DowloadFileEmployeeCsv")]
        public async Task<IActionResult> EmployeeCsv()
        {
            var result = await _employeeAppService.GetAll();
            var builder = new StringBuilder();
            builder.AppendLine("Id,BirthDate,Name,Email,DepartmentId");
            foreach (var item in result)
            {
                builder.AppendLine($"{item.Id},{item.BirthDate},{item.Name},{ item.Email},{ item.DepartmentId}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "employee.txt");
        }
    }
}
