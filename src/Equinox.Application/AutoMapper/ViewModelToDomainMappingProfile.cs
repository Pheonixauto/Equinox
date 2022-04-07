using AutoMapper;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands;
using Equinox.Domain.Commands.Department;
using Equinox.Domain.Commands.Employee;
using Equinox.Domain.Commands.EmployeeLearning;
using Equinox.Domain.Commands.EmployeeSkill;
using Equinox.Domain.Commands.Learning;
using Equinox.Domain.Commands.Relative;
using Equinox.Domain.Commands.Salary;
using Equinox.Domain.Commands.Skill;

namespace Equinox.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            CreateMap<EmployeeViewModel, RegisterNewEmployeeCommand>()
               .ConstructUsing(c => new RegisterNewEmployeeCommand(c.Name, c.Email, c.BirthDate,c.DepartmentId));
            CreateMap<EmployeeViewModel, UpdateEmployeeCommand>()
               .ConstructUsing(c => new UpdateEmployeeCommand(c.Id, c.Name, c.Email, c.BirthDate,c.DepartmentId));

            CreateMap<DepartmentViewModel, RegisterNewDepartmentCommand>()
              .ConstructUsing(c => new RegisterNewDepartmentCommand(c.Name));
            CreateMap<DepartmentViewModel, UpdateDepartmentCommand>()
              .ConstructUsing(c => new UpdateDepartmentCommand(c.Id, c.Name));

            CreateMap<RelativeViewModel, RegisterNewRelativeCommand>()
             .ConstructUsing(c => new RegisterNewRelativeCommand(c.Name, c.Email, c.BirthDate,c.EmployeeId));
            CreateMap<RelativeViewModel, UpdateRelativeCommand>()
                .ConstructUsing(c => new UpdateRelativeCommand(c.Id,c.Name,c.Email,c.BirthDate,c.EmployeeId));

            CreateMap<SalaryViewModel, RegisterNewSalaryCommand>()
                .ConstructUsing(c => new RegisterNewSalaryCommand(c.DateTime,c.BasicSalary,c.Tax,c.EmployeeId));
            CreateMap<SalaryViewModel, UpdateSalaryCommand>()
                .ConstructUsing(c => new UpdateSalaryCommand(c.Id, c.DateTime, c.BasicSalary, c.Tax, c.EmployeeId));

            CreateMap<LearningViewModel, RegisterNewLearningCommand>()
                .ConstructUsing(c => new RegisterNewLearningCommand(c.University));
            CreateMap<LearningViewModel, UpdateLearningCommand>()
                .ConstructUsing(c => new UpdateLearningCommand(c.Id,c.University));

            CreateMap<EmployeeLearningViewModel, RegisterNewEmployeeLearningCommand>()
                .ConstructUsing(c => new RegisterNewEmployeeLearningCommand(c.EmployeeId, c.LearningId, c.Major, c.Qualification));
            CreateMap<EmployeeLearningViewModel, UpdateEmployeeLearningCommand>()
                .ConstructUsing(c => new UpdateEmployeeLearningCommand(c.EmployeeId, c.LearningId, c.Major, c.Qualification));

            CreateMap<SkillViewModel, RegisterNewSkillCommand>()
                .ConstructUsing(c => new RegisterNewSkillCommand(c.Id, c.Name));
            CreateMap<SkillViewModel, UpdateSkillCommand>()
                .ConstructUsing(c => new UpdateSkillCommand(c.Name));

            CreateMap<EmployeeSkillViewModel, RegisterNewEmployeeSkillCommand>()
                .ConstructUsing(c => new RegisterNewEmployeeSkillCommand(c.EmployeeId, c.SkillId, c.Rating));
            CreateMap<EmployeeSkillViewModel, UpdateEmployeeSkillCommand>()
                .ConstructUsing(c => new UpdateEmployeeSkillCommand(c.EmployeeId,c.SkillId,c.Rating));
        }
    }
}
