using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Infra.Data.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<Salary> DbSet;
        public SalaryRepository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<Salary>();
        }


        public IUnitOfWork UnitOfWork => Db;

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Salary>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Salary> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);

        }

        public void Add(Salary salary)
        {
            DbSet.Add(salary);
        }

        public void Update(Salary salary)
        {
            DbSet.Update(salary);
        }

        public void Remove(Salary salary)
        {
            DbSet.Remove(salary);
        }

        public async Task<IList<Salary>> GetAllAsync(Expression<Func<Salary, bool>> expression = null, Func<IQueryable<Salary>, IOrderedQueryable<Salary>> orderBy = null, List<string> include = null)
        {
            IQueryable<Salary> query =DbSet;
            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (include != null)
            {
                foreach (var incudePropery in include)
                {
                    query = query.Include(incudePropery);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }
    }
}
