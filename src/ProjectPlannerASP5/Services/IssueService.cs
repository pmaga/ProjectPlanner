using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Data.Entity;
using Microsoft.Framework.Logging;
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
        private readonly ProjectPlannerContext _context;
        private readonly ILogger<IssueService> _logger;

        public IssueService(ProjectPlannerContext context, ILogger<IssueService> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<IssueView> GetIssues()
        {
            try
            {
                return _context.Issues.Include(i => i.Project).Project().To<IssueView>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get issues from database", ex);
                return null;
            }
        }

        public EditIssueViewModel GetIssue(int id)
        {
            try
            {
                return _context.Issues.Where(task => task.Id == id).Project().To<EditIssueViewModel>()
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
                _logger.LogError("Could not get issue from database", ex);
            }
        }

        public void Insert(EditIssueViewModel issueVm)
        {
            try
            {
                var issue = new Issue();
                Mapper.Map(issueVm, issue);

                _context.Issues.Add(issue);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not save issue into database", ex);
            }
        }

        public void Update(EditIssueViewModel issueVm)
        {
            try
            {
                var issue = _context.Issues.First(i => i.Id == issueVm.Id);

                Mapper.Map(issueVm, issue);
                issue.Status = IssueStatus.Modified;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not update issue in the database", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var issueToRemove = _context.Issues.FirstOrDefault(task => task.Id == id);
                _context.Issues.Remove(issueToRemove);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not delete issue from database", ex);
            }
        }
    }
}
