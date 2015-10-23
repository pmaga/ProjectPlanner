using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using ProjectPlannerASP5.Services;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Net;

namespace ProjectPlannerASP5.Controllers.Api
{
    [Authorize]
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectsService;

        public ProjectController(IProjectService projectsService, ILogger<ProjectController> logger)
        {
            _projectsService = projectsService;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var projects = _projectsService.GetProjects();
            
            return Json(projects);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]EditProjectViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Attempting to saving a new project.");

                    if (_projectsService.Insert(vm))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(new { id = vm.Id });
                    }
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
