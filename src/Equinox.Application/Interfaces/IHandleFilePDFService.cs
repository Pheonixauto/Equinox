using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface IHandleFilePDFService
    {
        Task<string> GetHtmlStringOfFileSalary(Guid employeeId, DateTime date);
        Task<byte[]> GetFilePdf(Guid id, DateTime date);
    }
}
