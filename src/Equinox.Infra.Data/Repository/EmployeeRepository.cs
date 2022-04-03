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
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<Employee> DbSet;
        public EmployeeRepository(EquinoxContext db)
        {
            Db = db;
            DbSet = Db.Set<Employee>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(Employee employee)
        {
            DbSet.Add(employee);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<Employee> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);

        }
    }
}
