using System;
using Autofac;
using Autofac.Extras.AggregateService;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NHibernate;
using ProjectPlanner.Cqrs.Base.DDD.Application;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations;
using ProjectPlanner.Infrastructure.Orm;
using ProjectPlanner.Infrastructure.Orm.Conventions;
using ProjectPlannerASP5.Application;
using ProjectPlanner.Projects.Interfaces.Presentation;
using ProjectPlanner.Projects.Presentation.Implementation;
using Project = ProjectPlanner.Projects.Domain.Project;
using Autofac.Framework.DependencyInjection;

namespace ProjectPlannerASP5.Configs
{
    public class ServicesConfig
    {
        public static IServiceProvider Configure(IServiceCollection services, IHostingEnvironment hostingEnv)
        {
            services.AddMvc(config =>
            {
                if (!hostingEnv.IsDevelopment())
                {
                    config.Filters.Add(new RequireHttpsAttribute());
                }
            })
            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.AddLogging();

            var builder = new ContainerBuilder();

            builder.RegisterType<SystemUser>().As<ISystemUser>();
            builder.RegisterType<ProjectFinder>().As<IProjectFinder>();
            RegisterOrm(builder);

            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        private static void RegisterOrm(ContainerBuilder container)
        {
            AutomappingConfiguration.IsEntityPredicate = e => e.IsDefined(typeof (DomainEntityAttribute), true);
            AutomappingConfiguration.IsComponentPredicate = e => e.IsDefined(typeof (DomainValueObjectAttribute), true);

            EntityManager.GetAssemblies = () => new[]
            {
                typeof(Project).Assembly
            };
            EntityManager.SeedData = s => new ProjectPlannerSeedData().SeedData(s);

            container.Register<ISessionFactory>(context => EntityManager.SessionFactory)
                .SingleInstance();
            container.Register<ISession>(context => EntityManager.SessionFactory.OpenSession())
                .InstancePerLifetimeScope();

            container.RegisterAggregateService<IPerRequestSessionFactory>();
            container.RegisterType<EntityManager>().As<IEntityManager>().SingleInstance();


        }
    }

    public class ProjectPlannerSeedData
    {
        public void SeedData(ISession session)
        {
            if (session.QueryOver<Project>().SingleOrDefault() == null)
            {
                var project = new Project(new Guid(), "JRS", "Name");

                session.Save(project);
                session.Flush();
            }
        }
    }
}
