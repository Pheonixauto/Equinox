using AutoMapper;
using CsvHelper;
using Equinox.Application.AutoMapper.CsvMapFile;
using Equinox.Application.DTO;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Services
{
    public class FileCsvService : IFileCsvService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public FileCsvService(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public Task<bool> AddEmployeeByCsv(IFormFile formFile)
        {
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture, leaveOpen: false))
            {
                csv.Context.RegisterClassMap<EmployeeMap>();
                var records1 = csv.GetRecords<ImportEmployeeDTO>();
                foreach (var item in records1)
                {
                    var result1 = _mapper.Map<Employee>(item);
                    if (result1.Id != Guid.Empty)
                    {
                        _employeeRepository.Add(result1);
                    }
                }
                return _employeeRepository.UnitOfWork.Commit();
            }
        }

    }
}
