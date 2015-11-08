using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using ProjectPlannerASP5.Services;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Net;
using System.Security.Claims;
using ProjectPlanner.Projects.Interfaces.Presentation;
using System.Linq;

namespace ProjectPlannerASP5.Controllers.Api
{
    //[Authorize]
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectFinder _projectFinder;

        public ProjectController(IProjectFinder projectsService, ILogger<ProjectController> logger)
        {
            _projectFinder = projectsService;
            _logger = logger;
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
            else
            {
                return Json(projects.ToList());
            }
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]EditProjectViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Attempting to saving a new project.");

                    //if (_projectsService.Insert(vm)) // TODO: ApplicationService albo Command
                    //{
                    //    Response.StatusCode = (int)HttpStatusCode.Created;
                    //    return Json(new { id = vm.Id });
                    //}
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
