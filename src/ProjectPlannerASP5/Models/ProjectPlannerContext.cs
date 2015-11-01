using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using ProjectPlannerASP5.Entities;

namespace ProjectPlannerASP5.Models
{
    public class ProjectPlannerContext : IdentityDbContext<AppUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }

        public ProjectPlannerContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:ProjectPlannerContextConnection"];
            
            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProjectUser>().HasKey(n => new { n.ProjectId, n.UserId });

            base.OnModelCreating(builder);
        }
    }
}
