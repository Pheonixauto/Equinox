using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IEmployeeSkillRepository : IRepository<EmployeeSkill>
    {
        Task<IEnumerable<EmployeeSkill>> GetAll();
        Task<EmployeeSkill> GetById(Guid employeeId, Guid skillId);
        void Add(EmployeeSkill employeeSkill);
        void Update(EmployeeSkill employeeSkill);
        void Remove(EmployeeSkill employeeSkill);
    }
}
