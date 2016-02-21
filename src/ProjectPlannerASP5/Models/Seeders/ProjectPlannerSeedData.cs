using System;
using NHibernate;
using ProjectPlanner.Projects.Domain;

namespace ProjectPlannerASP5.Models.Seeders
{
    public class ProjectPlannerSeedData
    {
        public void SeedData(ISession session)
        {
            if (session.QueryOver<Project>().SingleOrDefault() == null)
            {
                var project = new Project(new Guid(), "JRS", "Name");

                session.Save(project);
                session.Flush();
            }
        }
    }
}