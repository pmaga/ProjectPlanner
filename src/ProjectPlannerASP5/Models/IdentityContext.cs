using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace ProjectPlannerASP5.Models
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:ProjectPlannerIdentityConnection"];

            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
