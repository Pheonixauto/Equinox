using CsvHelper.Configuration;
using Equinox.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.AutoMapper.CsvMapFile
{
    public class EmployeeMap : ClassMap<ImportEmployeeDTO>
    {
        public EmployeeMap()
        {
            Map(m => m.Id).Name("Id").TypeConverterOption.NullValues("Guid.Empty");
            Map(m => m.Name).Name("Name");
            Map(m => m.BirthDate).Name("BirthDate");
            Map(m => m.Email).Name("Email");
            Map(m => m.DepartmentId).Name("DepartmentId");
        }
    }
}
