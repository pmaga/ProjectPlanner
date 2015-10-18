using ProjectPlannerASP5.Entites;
using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlannerASP5.Services
{
    public class IssueService : IIssueService
    {
        public IEnumerable<IssueView> GetIssues()
        {
            return new List<IssueView>
            {
                new IssueView {Id = 1, CreateDate = DateTime.Now, DueDate = DateTime.Now, Description = "Descr",
                Status = IssueStatus.Modified, Summary = "Summaryyy", IssueFullNumber = "HH-3"}
            };
            //using (var ctx = new ProjectPlannerDbContext())
            //{
            //    return ctx.Issues.Include(i => i.Project).Project().To<IssueView>().ToList();
            //}
        }

        public EditIssueViewModel GetIssue(int id)
        {
            return new EditIssueViewModel
            {
                Id = 1,
                DueDate = DateTime.Now,
                Description = "Descr",
                Summary = "Summaryyy"
            };
            //using (var ctx = new ProjectPlannerDbContext())
            //{
            //    return ctx.Issues.Where(task => task.Id == id).Project().To<EditIssueViewModel>()
            //        .FirstOrDefault();
            //}
        }

        public void Insert(EditIssueViewModel issueVm)
        {
            //using (var ctx = new ProjectPlannerDbContext())
            //{
            //    var issue = new Issue();
            //    Mapper.Map(issueVm, issue);

            //    ctx.Issues.Add(issue);
            //    ctx.SaveChanges();
            //}
        }

        public void Update(EditIssueViewModel issueVm)
        {
        //    using (var ctx = new ProjectPlannerDbContext())
        //    {
        //        var issue = ctx.Issues.First(i => i.Id == issueVm.Id);

        //        Mapper.Map(issueVm, issue);
        //        issue.Status = EntityStatus.Modified;

        //        ctx.SaveChanges();
        //    }
        }

        public void Delete(int id)
        {
            //using (var ctx = new ProjectPlannerDbContext())
            //{
            //    var taskToRemove = ctx.Issues.FirstOrDefault(task => task.Id == id);
            //    ctx.Issues.Remove(taskToRemove);
            //    ctx.SaveChanges();
            //}
        }
    }
}
