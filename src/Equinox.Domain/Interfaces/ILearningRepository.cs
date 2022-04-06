using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface ILearningRepository : IRepository<Learning>
    {
        Task<IEnumerable<Learning>> GetAll();
        Task<Learning> GetById(Guid id);
        Task<Learning>GetByUniversity(string university);
        void Add(Learning learning);
        void Update(Learning learning);
        void Remove(Learning learning);
    }
}
