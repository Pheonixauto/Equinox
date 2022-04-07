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
    public class EmployeeSkillRepository : IEmployeeSkillRepository
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<EmployeeSkill> DbSet;
        public EmployeeSkillRepository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<EmployeeSkill>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(EmployeeSkill employeeSkill)
        {
            DbSet.Add(employeeSkill);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<EmployeeSkill>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<EmployeeSkill> GetById(Guid employeeId, Guid skillId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.EmployeeId == employeeId && c.SkillId == skillId);
        }

        public void Remove(EmployeeSkill employeeSkill)
        {
            DbSet.Remove(employeeSkill);
        }

        public void Update(EmployeeSkill employeeSkill)
        {
            DbSet.Update(employeeSkill);
        }
    }
}
