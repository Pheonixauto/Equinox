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
    public class SkillRepository : ISkillRepository
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<Skill> DbSet;
        public SkillRepository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<Skill>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(Skill skill)
        {
            DbSet.Add(skill);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Skill> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Remove(Skill skill)
        {
            DbSet.Remove(skill);
        }

        public void Update(Skill skill)
        {
            DbSet.Update(skill);
        }
    }
}
