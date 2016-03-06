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
                var project = new Project(new Guid(), "ATH", "University of Bielsko-Biala");
                project.SetDescription(@"There are many variations of passages of Lorem Ipsum available, but 
the majority have suffered alteration in some form, by injected humour, or randomised words which don't look
even slightly believable.If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't 
anything embarrassing");

                session.Save(project);
                session.Flush();
            }
        }
    }
}