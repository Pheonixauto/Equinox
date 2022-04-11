using DinkToPdf;
using DinkToPdf.Contracts;
using Equinox.Application.Interfaces;
using Equinox.Application.Services;
using Equinox.Domain.Commands;
using Equinox.Domain.Core.Events;
using Equinox.Domain.Events;
using Equinox.Domain.Interfaces;
using Equinox.Infra.CrossCutting.Bus;
using Equinox.Infra.Data.Context;
using Equinox.Infra.Data.EventSourcing;
using Equinox.Infra.Data.Repository;
using Equinox.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using Jira.Application.Interface;
using Jira.Application.Service;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Equinox.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IEmployeeAppService, EmployeeAppService>();
            services.AddScoped<IDepartmentAppService, DepartmentAppService>();
            services.AddScoped<IRelativeAppService,RelativeAppService>();
            services.AddScoped<ISalaryAppService, SalaryAppService>();
            services.AddScoped<ILearningAppService, LearningAppService>();
            services.AddScoped<IEmployeeLearningAppService, EmployeeLearningAppService>();
            services.AddScoped<ISkillAppService, SkillAppService>();
            services.AddScoped<IEmployeeSkillAppService, EmployeeSkillAppService>();
            services.AddScoped<IFileCsvService, FileCsvService>();
            services.AddScoped<IHttpClientJiraService, HttpClientJiraService>();




            // Domain - Events
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IRelativeRepository,RelativeRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<ILearningRepository, LearningRepository>();
            services.AddScoped<IEmployeeLearningRepository, EmployeeLearningRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IEmployeeSkillRepository, EmployeeSkillRepository>();

            services.AddScoped<EquinoxContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}