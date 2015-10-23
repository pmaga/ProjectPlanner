using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Data.Entity;
using Microsoft.Framework.Logging;
using ProjectPlannerASP5.Entites;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectPlannerASP5.Models;

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

        public IEnumerable<IssueView> GetIssuesByProjectCode(string projectCode)
        {
            try
            {
                return _context.Issues.Include(i => i.Project)
                    .Where(issue => issue.Project.Code == projectCode)
                    .OrderBy(issue => issue.CreateDate).ProjectTo<IssueView>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not get issues for project: {projectCode}", ex);
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
                _logger.LogError("Could not get issue from database", ex);
                return null;
            }
        }

        public bool Insert(string projectCode, EditIssueViewModel issueVm)
        {
            try
            {
                var project = _context.Projects.FirstOrDefault(p => p.Code == projectCode);

                var issue = Mapper.Map<Issue>(issueVm);
                issue.ProjectId = project.Id;

                _context.Issues.Add(issue);
                var result = _context.SaveChanges() > 0;
                issueVm.Id = issue.Id;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not save issue into database", ex);
                return false;
            }
        }

        public bool Update(EditIssueViewModel issueVm)
        {
            try
            {
                var issue = _context.Issues.First(i => i.Id == issueVm.Id);

                Mapper.Map(issueVm, issue);
                issue.Status = IssueStatus.Modified;

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not update issue in the database", ex);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var issueToRemove = _context.Issues.FirstOrDefault(issue => issue.Id == id);
                _context.Issues.Remove(issueToRemove);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not delete issue from database", ex);
                return false;
            }
        }
    }
}