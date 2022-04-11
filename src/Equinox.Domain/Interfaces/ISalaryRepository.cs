using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface ISalaryRepository : IRepository<Salary>
    {
        Task<IEnumerable<Salary>> GetAll();
        Task<Salary> GetById(Guid id);
        void Add(Salary salary);
        void Update(Salary salary);
        void Remove(Salary salary);


        Task<IList<Salary>> GetAllAsync(
          Expression<Func<Salary, bool>> expression = null,
          Func<IQueryable<Salary>, IOrderedQueryable<Salary>> orderBy = null,
          List<string> include = null
          );
    }
}
