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
    public class EmployeeLearningRepository : IEmployeeLearningRepository
    {
        private readonly EquinoxContext Db;
        private readonly DbSet<EmployeeLearning> DbSet;
        public EmployeeLearningRepository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<EmployeeLearning>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(EmployeeLearning employeeLearning)
        {
            DbSet.Add(employeeLearning);
        }

        public void Dispose()
        {
            Db.Dispose();

        }

        public async Task<IEnumerable<EmployeeLearning>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<EmployeeLearning> GetById(Guid employeeId, Guid learningId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.EmployeeId == employeeId && c.LearningId == learningId);
        }

        public void Remove(EmployeeLearning employeeLearning)
        {
            DbSet.Remove(employeeLearning);
        }

        public void Update(EmployeeLearning employeeLearning)
        {
            DbSet.Update(employeeLearning);
        }
    }
}
