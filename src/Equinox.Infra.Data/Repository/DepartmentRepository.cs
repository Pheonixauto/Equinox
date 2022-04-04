using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Infra.Data.Repository
{
    public class DepartmentRepository :IDepartmentRepository
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<Department> DbSet;
        public DepartmentRepository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<Department>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Add(Department department)
        {
            DbSet.Add(department);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {

            return await DbSet.ToListAsync();
        }

        public async Task<Department> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Department> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public void Remove(Department department)
        {
            DbSet.Remove(department);
        }

        public void Update(Department department)
        {
            DbSet.Update(department);
        }
    }
}
