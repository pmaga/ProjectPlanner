﻿using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using Microsoft.Dnx.Runtime;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Builder;
using ProjectPlannerASP5.Configs;
using Microsoft.Framework.Logging;
using ProjectPlannerASP5.Models;

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

        public async void Configure(IApplicationBuilder app, ProjectPlannerContextSeedData seeder, ILoggerFactory loggerFactory,
            IHostingEnvironment env)
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

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/App/Error");
            }

            app.UseIISPlatformHandler();

            await seeder.EnsureSeedDataAsync();

            MappingConfig.RegisterMaps();
        }
    }
}