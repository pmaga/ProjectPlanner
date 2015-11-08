using System;
using Autofac;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using Microsoft.Dnx.Runtime;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Builder;
using ProjectPlannerASP5.Configs;
using Microsoft.Framework.Logging;
using ProjectPlanner.Cqrs.Base.DDD.Application;
using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.Services;

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
            ServicesConfig.Configure(services, _env);
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory,
            IHostingEnvironment env)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddDebug(LogLevel.Warning);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/App/Error");
            }

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });
        }
    }
}