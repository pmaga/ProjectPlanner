using System;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.AggregateService;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NHibernate;
using ProjectPlanner.Cqrs.Base.DDD.Application;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations;
using ProjectPlanner.Infrastructure.Orm;
using ProjectPlanner.Infrastructure.Orm.Conventions;
using ProjectPlannerASP5.Application;
using Project = ProjectPlanner.Projects.Domain.Project;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Cqrs.Base.CQRS.Query.Attributes;
using ProjectPlanner.Cqrs.Base.DDD.Infrastructure.Events.Implementation;
using ProjectPlanner.Cqrs.Base.Infrastructure.Attributes;
using ProjectPlanner.Projects.Interfaces.Application.Commands;
using ProjectPlanner.Projects.Interfaces.Presentation;
using ProjectPlanner.Projects.Presentation.Implementation;
using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.Models.Seeders;

namespace ProjectPlannerASP5.Configs
{
    public class ServicesConfig
    {
        public static IServiceProvider Configure(IServiceCollection services, IHostingEnvironment hostingEnv)
        {
            ConfigureMvcServices(services, hostingEnv);

            var container = ConfigureAutofacServices(services);

            return container.Resolve<IServiceProvider>();
        }

        private static void ConfigureMvcServices(IServiceCollection services, IHostingEnvironment hostingEnv)
        {
            services.AddMvc(config =>
            {
                if (!hostingEnv.IsDevelopment())
                {
                    config.Filters.Add(typeof(RequireHttpsAttribute));
                }
            })
            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<IdentityContext>();

            services.AddLogging();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<IdentityContext>();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Cookies.ApplicationCookie.CookieName = "authCookie";
            //    options.Cookies.ApplicationCookie.LoginPath = new Microsoft.AspNet.Http.PathString("/Auth/Login");
            //    options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
            //    {
            //        OnRedirect = ctx =>
            //        {
            //            if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
            //            {
            //                ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //            }
            //            else
            //            {
            //                ctx.Response.Redirect(ctx.RedirectUri);
            //            }

            //            return Task.FromResult<object>(null);
            //        }
            //    };
            //});

            services.AddTransient<IdentityContextSeedData>();
        }

        private static IContainer ConfigureAutofacServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            var domainAssemblies = new[]
            {
                typeof (ProjectFinder).Assembly,
                typeof (IProjectFinder).Assembly
            };
            builder.RegisterType<SystemUser>().As<ISystemUser>();
            builder.RegisterType<IdentityContextSeedData>().AsSelf();

            builder.RegisterAssemblyTypes(domainAssemblies)
                .Where(t => t.IsComponentLifestyle(ComponentLifestyle.Transient) ||
                            t.IsDefined(typeof(FinderAttribute), true) ||
                            t.IsDefined(typeof(DomainServiceAttribute), true) ||
                            t.IsDefined(typeof(DomainRepositoryAttribute), true) ||
                            t.IsDefined(typeof(DomainFactoryAttribute), true))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.IsComponentLifestyle(ComponentLifestyle.Singleton))
                .AsImplementedInterfaces()
                .AsSelf()
                .SingleInstance();

            RegisterOrm(builder);

            builder.RegisterAggregateService<IPerRequestSessionFactory>();
            builder.RegisterAggregateService<ICommandHandlerFactory>();
            builder.RegisterType<EntityManager>().As<IEntityManager>().SingleInstance();
            builder.RegisterType<CreateProjectCommand>().AsSelf();
            builder.RegisterType<EventPublisher>().AsImplementedInterfaces()
                .SingleInstance();


            builder.RegisterAssemblyTypes(domainAssemblies)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();

            builder.Populate(services);

            var container = builder.Build();
            return container;
        }

        private static void RegisterOrm(ContainerBuilder builder)
        {
            AutomappingConfiguration.IsEntityPredicate = e => e.IsDefined(typeof(DomainEntityAttribute), true);
            AutomappingConfiguration.IsComponentPredicate = e => e.IsDefined(typeof(DomainValueObjectAttribute), true);

            EntityManager.GetAssemblies = () => new[]
            {
                typeof(Project).Assembly
            };
            EntityManager.SeedData = s => new ProjectPlannerSeedData().SeedData(s);

            builder.Register<ISessionFactory>(context => EntityManager.SessionFactory)
                .SingleInstance();
            builder.Register<ISession>(context => EntityManager.SessionFactory.OpenSession())
                .InstancePerLifetimeScope();
        }
    }
}
