using Microsoft.Framework.DependencyInjection;
using ProjectPlannerASP5.Services;
using Microsoft.Framework.Configuration;
using ProjectPlannerASP5.Models;
using Microsoft.Dnx.Runtime;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Builder;
using ProjectPlannerASP5.Configs;
using Microsoft.Framework.Logging;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;

namespace ProjectPlannerASP5
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        private readonly IHostingEnvironment _env;

        public Startup(IApplicationEnvironment appEnv, IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                if (!_env.IsDevelopment())
                {
                    config.Filters.Add(new RequireHttpsAttribute());
                }
            })
            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<ProjectPlannerContext>();

            services.AddLogging();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ProjectPlannerContext>();

            services.AddTransient<ProjectPlannerContextSeedData>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IProjectService, ProjectService>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Cookies.ApplicationCookie.LoginPath = new Microsoft.AspNet.Http.PathString("/Auth/Login");
            });
        }

        public async void Configure(IApplicationBuilder app, ProjectPlannerContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Warning);

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            app.UseIISPlatformHandler();

            await seeder.EnsureSeedDataAsync();

            MappingConfig.RegisterMaps();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("");
            //});
        }
    }
}