using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using ProjectPlannerASP5.Entites;

namespace ProjectPlannerASP5.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnConfiguring(EntityOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:AppContextConnection"];

            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
