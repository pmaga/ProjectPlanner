using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ProjectPlannerASP5.Services;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Net;
using ProjectPlannerASP5.Base.Cqrs.Base.CQRS.Commands;
using ProjectPlannerASP5.Projects.Abstract.Presentation;

namespace ProjectPlannerASP5.Controllers.Api
{
    //[Authorize]
    [Route("api/projects/{projectCode}/issues")]
    public class IssueController : Controller
    {
        private readonly IGate _gate;
        private readonly ILogger<IssueController> _logger;
        private readonly IIssuesFinder _issueFinder;

        public IssueController(IGate gate, ILogger<IssueController> logger, IIssuesFinder issueFinder)
        {
            _gate = gate;
            _logger = logger;
            _issueFinder = issueFinder;
        }

        [HttpGet("")]
        public JsonResult Get(string projectCode)
        {
            try
            {
                var results = _issueFinder.FindIssues(projectCode);

                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get issues for project: {projectCode}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured finding the issues");
            }
        }

        [HttpPost("")]
        public JsonResult Post(string projectCode, [FromBody]EditIssueViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Attempting to saving new issue.");

                    //if (_issueService.Insert(projectCode, vm))
                    //{
                    //    Response.StatusCode = (int)HttpStatusCode.Created;
                    //    return Json(new { id = vm.Id });
                    //}
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new issue", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed to save new issue");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Validation failed on new issue");
        }
    }
}
