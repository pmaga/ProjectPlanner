using AutoMapper.QueryableExtensions;
using ProjectPlannerASP5.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectPlannerASP5.ViewModels;
using Microsoft.Framework.Logging;
using AutoMapper;
using ProjectPlannerASP5.Models;

namespace ProjectPlannerASP5.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectPlannerContext _context;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(ProjectPlannerContext context, ILogger<ProjectService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<ProjectView> GetProjects()
        {
            try
            {
                return _context.Projects.Where(n => true)
                    .Project().To<ProjectView>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get projects from database.", ex);
                return null;
            }
        }

        public EditProjectViewModel GetProject(int id)
        {
            try
            {
                return _context.Projects.Where(project => project.Id == id).
                    Project().To<EditProjectViewModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get project from database.", ex);
                return null;
            }
        }

        public bool Insert(EditProjectViewModel projectVm)
        {
            try
            {
                var project = Mapper.Map<Project>(projectVm);

                _context.Projects.Add(project);
                var result = _context.SaveChanges() > 0;

                projectVm.Id = project.Id;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not save project into the database.", ex);
                return false;
            }
        }

        public bool Update(EditProjectViewModel projectVm)
        {
            try
            {
                var project = _context.Projects.First(i => i.Id == projectVm.Id);

                Mapper.Map(projectVm, project);
                return _context.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError("Could not update project in the database", ex);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var projectToRemove = _context.Projects.FirstOrDefault(project => project.Id == id);
                _context.Projects.Remove(projectToRemove);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not delete project from database", ex);
                return false;
            }
        }
    }
}
