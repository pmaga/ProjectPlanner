using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Net;
using ProjectPlanner.Projects.Interfaces.Presentation;
using System.Linq;
using ProjectPlanner.Cqrs.Base.CQRS.Commands;
using ProjectPlanner.Projects.Interfaces.Application.Commands;

namespace ProjectPlannerASP5.Controllers.Api
{
    //[Authorize]
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IGate _gate;
        private readonly IProjectFinder _projectFinder;

        public ProjectController(IProjectFinder projectsService, ILogger<ProjectController> logger,
            IGate gate)
        {
            _projectFinder = projectsService;
            _logger = logger;
            _gate = gate;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var projects = _projectFinder.FindProjects();

            if (projects == null)
            {
                //Response.StatusCode = (int)HttpStatusCode.NoContent;
                return Json(null);
            }

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
    }
}