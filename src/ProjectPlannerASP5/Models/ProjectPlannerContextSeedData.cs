using ProjectPlannerASP5.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectPlannerASP5.Models
{
    public class ProjectPlannerContextSeedData
    {
        private readonly ProjectPlannerContext _context;

        public ProjectPlannerContextSeedData(ProjectPlannerContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Projects.Any())
            {
                // Add new data
                var project = new Project
                {
                    Code = "JRS",
                    Name = "JRSSSS",
                    CreateDate = DateTime.UtcNow,
                    Creator = "",
                    Status = ProjectStatus.Active,
                    Issues = new List<Issue>
                    {
                        new Issue { IssueNumber = 1, Summary = "Title", UserName = "", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 2, Summary = "Title 2", UserName = "", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 3, Summary = "Title 3", UserName = "", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 4, Summary = "Title 4", UserName = "", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 5, Summary = "Title 5", UserName = "", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 6, Summary = "Title 6", UserName = "", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 7, Summary = "Title 7", UserName = "", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) }
                    }
                };

                _context.Projects.Add(project);
                _context.Issues.AddRange(project.Issues);

                _context.SaveChanges();
                
            }
        }
    }
}
