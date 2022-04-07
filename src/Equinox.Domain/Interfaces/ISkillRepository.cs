using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task<IEnumerable<Skill>> GetAll();
        Task<Skill> GetById(Guid id);
        void Add (Skill skill);
        void Update(Skill skill);
        void Remove(Skill skill);
    }
}
