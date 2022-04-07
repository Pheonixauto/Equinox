using Equinox.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IEmployeeLearningRepository: IRepository<EmployeeLearning>
    {
        Task<IEnumerable<EmployeeLearning>> GetAll();
        Task<EmployeeLearning> GetById(Guid employeeId, Guid learningId);
        void Add(EmployeeLearning employeeLearning);
        void Update(EmployeeLearning employeeLearning);
        void Remove(EmployeeLearning employeeLearning);
    }
}
