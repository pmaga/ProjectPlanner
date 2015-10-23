using Microsoft.AspNet.Identity;
using ProjectPlannerASP5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlannerASP5.Entites
{
    public class ProjectPlannerContextSeedData
    {
        private readonly ProjectPlannerContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProjectPlannerContextSeedData(ProjectPlannerContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("pawel.p.maga@gmail.com") == null)
            {
                var newUser = new AppUser
                {
                    UserName = "pawelmaga",
                    Email = "pawel.p.maga@gmail.com"
                };

                await _userManager.CreateAsync(newUser, "P@ssw0rd");
            }


            if (!_context.Projects.Any())
            {
                // Add new data
                var project = new Project
                {
                    Code = "JRS",
                    Name = "JRSSSS",
                    CreateDate = DateTime.UtcNow,
                    Creator = await _userManager.FindByEmailAsync("pawel.p.maga@gmail.com"),
                    Status = ProjectStatus.Active,
                    Issues = new List<Issue>
                    {
                        new Issue { IssueNumber = 1, Summary = "Title", UserName = "pawelmaga", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 2, Summary = "Title 2", UserName = "pawelmaga", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 3, Summary = "Title 3", UserName = "pawelmaga", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 4, Summary = "Title 4", UserName = "pawelmaga", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 5, Summary = "Title 5", UserName = "pawelmaga", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 6, Summary = "Title 6", UserName = "pawelmaga", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) },
                        new Issue { IssueNumber = 7, Summary = "Title 7", UserName = "pawelmaga", LastChangeDate = DateTime.UtcNow, Description = "Opis", Status = IssueStatus.Added, CreateDate = DateTime.UtcNow, DueDate = DateTime.Now.AddDays(14) }
                    }
                };

                _context.Projects.Add(project);
                _context.Issues.AddRange(project.Issues);

                _context.SaveChanges();
                
            }
        }
    }
}
