using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> GetById(Guid id);
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetByName(string name);

        void Add(Department department);
        void Update(Department department);
        void Remove(Department department);




    }
}
