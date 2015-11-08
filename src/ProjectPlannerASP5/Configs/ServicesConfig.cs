using System;
using Autofac;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.Services;
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
        public static void Configure(IServiceCollection services, IHostingEnvironment hostingEnv)
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

            //var builder = new ContainerBuilder();

            //services.AddTransient<ProjectPlannerContextSeedData>();

            //builder.RegisterType<IssueService>().As<IIssueService>();
            //builder.RegisterType<ProjectService>().As<IProjectService>();
            //builder.RegisterType<SystemUser>().As<ISystemUser>();
            //builder.RegisterType<ProjectFinder>().As<IProjectFinder>();
            //builder.RegisterType<EntityManager>().As<IEntityManager>();
            //RegisterOrm();

            //builder.Populate(services);

            //var container = builder.Build();

            services.AddScoped(typeof (ISystemUser), typeof (SystemUser));
            //return services.BuildServiceProvider();

           // return container.Resolve<IServiceProvider>();
        }

        private static void RegisterOrm()
        {
            AutomappingConfiguration.IsEntityPredicate = e => e.IsDefined(typeof (DomainEntityAttribute), true);
            AutomappingConfiguration.IsComponentPredicate = e => e.IsDefined(typeof (DomainValueObjectAttribute), true);

            EntityManager.SeedData = s => new ProjectPlannerSeedData().SeedData(s);
        }
    }

    public class ProjectPlannerSeedData
    {
        public void SeedData(ISession session)
        {
            //if (await _userManager.FindByEmailAsync("pawel.p.maga@gmail.com") == null)
            //{
            //    var newUser = new AppUser
            //    {
            //        UserName = "pawelmaga",
            //        Email = "pawel.p.maga@gmail.com"
            //    };

            //    await _userManager.CreateAsync(newUser, "P@ssw0rd");
            //}

            if (session.QueryOver<Project>().SingleOrDefault() == null)
            {
                //var user = await _userManager.FindByEmailAsync("pawel.p.maga@gmail.com");

                var project = new Project(new Guid(), "JRS", "Name");

                session.Save(project);
                session.Flush();
            }
        }
    }
}
