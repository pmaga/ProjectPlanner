using System;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using Microsoft.Dnx.Runtime;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Builder;
using ProjectPlannerASP5.Configs;
using Microsoft.Framework.Logging;
using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.Models.Seeders;

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

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return ServicesConfig.Configure(services, _env);
        }

        public async void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory,
            IHostingEnvironment env, IdentityContextSeedData seeder)
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

            await seeder.EnsureSeedDataAsync();
        }
    }
}