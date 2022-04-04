using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetById(Guid id);
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetByEmail(string email);

        void Add(Employee employee);
        void Update(Employee employee);
        void Remove (Employee employee);

    }
}
