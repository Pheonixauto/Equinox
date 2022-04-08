using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface IFileCsvService 
    {
        Task<bool> AddEmployeeByCsv(IFormFile formFile);
    }
}
