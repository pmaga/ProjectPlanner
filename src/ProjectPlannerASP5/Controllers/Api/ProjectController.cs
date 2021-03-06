﻿using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Net;
using ProjectPlanner.Projects.Interfaces.Presentation;
using System.Linq;
using ProjectPlanner.Cqrs.Base.CQRS.Commands;
using ProjectPlanner.Projects.Interfaces.Application.Commands;
using Microsoft.AspNet.Authorization;

namespace ProjectPlannerASP5.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IGate _gate;
        private readonly IProjectFinder _projectFinder;

        public ProjectsController(IProjectFinder projectsService, ILogger<ProjectsController> logger,
            IGate gate)
        {
            _projectFinder = projectsService;
            _logger = logger;
            _gate = gate;
        }

        [HttpGet("")]
        public JsonResult All()
        {
            try
            {
                var projects = _projectFinder.FindProjects().ToList();

                return Json(projects.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get projects", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured finding the projects");
            }
        }

        [HttpGet("{projectId}")]
        public JsonResult Get(int projectId)
        {
            try
            {
                var project = _projectFinder.GetProject(projectId);

                return Json(project);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get details for project with id: {projectId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured finding the project");
            }
        }

        [HttpPost("")]
        public JsonResult Create([FromBody]EditProjectViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Attempting to saving a new project.");

                    var createProjectCommand = new CreateProjectCommand(vm.Code, vm.Name, vm.Description);
                    _gate.Dispatch(createProjectCommand);
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(new { id = createProjectCommand.ProjectId });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new project", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpPut("")]
        public JsonResult Update([FromBody]EditProjectViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Attempting to updating a project with code: {vm.Code}.");

                    var changeProjectInformationCommand = new ChangeProjectInformationCommand(vm.Id, vm.Code, vm.Name, vm.Description);
                    _gate.Dispatch(changeProjectInformationCommand);
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update project", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Attempting to delete a project with id: {id}.");

                    var deleteProjectCommand = new DeleteProjectCommand(id);
                    _gate.Dispatch(deleteProjectCommand);
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json("");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete project", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpGet("{projectId}/[action]")]
        public JsonResult Details(int projectId)
        {
            var project = _projectFinder.GetProjectDetails(projectId);

            if (project == null)
            {
                //Response.StatusCode = (int)HttpStatusCode.NoContent;
                return Json(null);
            }

            return Json(project);
        }

        [HttpGet("getlookups")]
        public JsonResult GetProjectLookups()
        {
            var projects = _projectFinder.GetProjectLookups();

            return Json(projects);
        }
    }
}