using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ProjectPlannerASP5.Controllers.Web;
using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.Services;
using System.Net;
using System.Threading.Tasks;

namespace ProjectPlannerASP5.Configs
{
    public class ServicesConfig
    {
        public static void Configure(IServiceCollection services, IHostingEnvironment hostingEnv)
        {
            AddFrameworkDependedServices(services, hostingEnv);
            AddCustomServices(services);
        }

        private static void AddFrameworkDependedServices(IServiceCollection services, IHostingEnvironment hostingEnv)
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

            services.Configure<IdentityOptions>(options =>
            {
                options.Cookies.ApplicationCookie.CookieName = "authCookie";
                options.Cookies.ApplicationCookie.LoginPath = new Microsoft.AspNet.Http.PathString("/Auth/Login");
                options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirect = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }

                        return Task.FromResult<object>(null);
                    }
                };
            });
        }

        private static void AddCustomServices(IServiceCollection services)
        {
            services.AddTransient<ProjectPlannerContextSeedData>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}
