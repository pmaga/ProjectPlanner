using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using ProjectPlannerASP5.Services;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;
using ProjectPlannerASP5.Models;

namespace ProjectPlannerASP5
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)//, IHostingEnvironment env)
        {
            services.AddMvc();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppContext>();

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

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("");
            //});
        }
    }
}