using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using ProjectPlannerASP5.Configs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using ProjectPlannerASP5.Models.Seeders;
using Microsoft.AspNet.Identity;

namespace ProjectPlannerASP5
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        private readonly IHostingEnvironment _env;

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);

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
            services.Configure<IdentityOptions>(options =>
            {
                options.Cookies.ApplicationCookie.LoginPath = new PathString("/Auth/Login");
            });

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

            app.UseIdentity();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            //app.UseCookieAuthentication(options =>
            //{
            //    options.AccessDeniedPath = new PathString("/Home/AccessDenied");
            //    options.LoginPath = new PathString("/Auth/Login");
            //});
         
            await seeder.EnsureSeedDataAsync();
        }
    }
}