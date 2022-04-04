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
    public class RelativeRepository : IRelativeRepository
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<Relative> DbSet;
        public RelativeRepository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<Relative>();

        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(Relative relative)
        {
          DbSet.Add(relative);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Relative>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Relative> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
