﻿using Microsoft.Framework.DependencyInjection;
using ProjectPlannerASP5.Services;
using Microsoft.Framework.Configuration;
using ProjectPlannerASP5.Models;
using Microsoft.Dnx.Runtime;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Builder;
using ProjectPlannerASP5.Configs;
using Microsoft.Framework.Logging;

namespace ProjectPlannerASP5
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)//, IHostingEnvironment env)
        {
            services.AddMvc();
            services.AddLogging();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ProjectPlannerContext>();

            services.AddTransient<ProjectPlannerContextSeedData>();

            //if (env.IsDevelopment())
            //{
            //    services.AddScoped<IMailService, DebugMailService>();
            //}
            //else
            //{
            //    // user real mail service
            //}

            services.AddScoped<IIssueService, IssueService>();
        }

        public void Configure(IApplicationBuilder app, ProjectPlannerContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Warning);

            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            app.UseIISPlatformHandler();

            seeder.EnsureSeedData();

            MappingConfig.RegisterMaps();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("");
            //});
        }
    }
}