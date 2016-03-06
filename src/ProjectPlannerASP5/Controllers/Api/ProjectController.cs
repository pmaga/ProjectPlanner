using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Net;
using ProjectPlanner.Projects.Interfaces.Presentation;
using System.Linq;
using ProjectPlanner.Cqrs.Base.CQRS.Commands;
using ProjectPlanner.Projects.Interfaces.Application.Commands;
using Microsoft.AspNet.Authorization;
using ProjectPlanner.Projects.Presentation;

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
        public JsonResult Get()
        {
            var projects = _projectFinder.FindProjects().ToList();

            if (projects == null)
            {
                //Response.StatusCode = (int)HttpStatusCode.NoContent;
                return Json(null);
            }
            var first = projects.First();
            first.PercentageCompleteness = 10;
            return Json(projects.ToList());
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]EditProjectViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Attempting to saving a new project.");

                    var createProjectCommand = new CreateProjectCommand(vm.Code, vm.Name);
                    _gate.Dispatch(createProjectCommand);

                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(new {id = createProjectCommand.ProjectId});
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

        [HttpGet("{projectId}/[action]")]
        public JsonResult Details(int projectId)
        {
            var project = _projectFinder.FindProject(projectId);

            if (project == null)
            {
                //Response.StatusCode = (int)HttpStatusCode.NoContent;
                return Json(null);
            }

            return Json(project);
        }

    }
}