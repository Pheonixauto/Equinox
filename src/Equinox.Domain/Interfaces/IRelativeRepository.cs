using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IRelativeRepository : IRepository<Relative>
    {
        Task<IEnumerable<Relative>> GetAll();
        Task<Relative> GetByEmail(string email);
        Task<Relative> GetById(Guid id);

        void Add(Relative relative);
        void Update(Relative relative);
        void Remove(Relative relative);

    }
}
