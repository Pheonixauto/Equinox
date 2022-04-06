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
    public class LearningRepository : ILearningRepository
    {
        private readonly EquinoxContext Db;
        private readonly DbSet<Learning> DbSet;
        public LearningRepository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<Learning>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(Learning learning)
        {
            DbSet.Add(learning);
        }

        public void Remove(Learning learning)
        {
            Db.Remove(learning);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Learning>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Learning> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Learning> GetByUniversity(string university)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.University == university);
        }

        public void Update(Learning learning)
        {
            DbSet.Update(learning);
        }
    }
}
