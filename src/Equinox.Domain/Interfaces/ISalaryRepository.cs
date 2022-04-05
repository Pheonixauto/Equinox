using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface ISalaryRepository : IRepository<Salary>
    {
        Task<IEnumerable<Salary>> GetAll();
        Task<Salary> GetById(Guid id);
        void Add(Salary salary);
    }
}
