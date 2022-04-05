using Equinox.Domain.Commands.Salary.Events;
using Equinox.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.Commands.Salary
{
    public class SalaryCommandHandler : CommandHandler,
         IRequestHandler<RegisterNewSalaryCommand, ValidationResult>
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryCommandHandler(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }
        public async Task<ValidationResult> Handle(RegisterNewSalaryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var salary = new Models.Salary(Guid.NewGuid(),message.DateTime, message.BasicSalary, message.Tax, message.EmployeeId);


            salary.AddDomainEvent(new SalaryRegisteredEvent(message.Id, message.DateTime,message.BasicSalary,message.Tax,message.EmployeeId));

            _salaryRepository.Add(salary);

            return await Commit(_salaryRepository.UnitOfWork);
        }
    }
}
