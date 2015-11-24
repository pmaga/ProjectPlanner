using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ProjectPlannerASP5.Services;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Net;

namespace ProjectPlannerASP5.Controllers.Api
{
    //[Authorize]
    [Route("api/projects/{projectCode}/issues")]
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        private readonly ILogger<IssueController> _logger;

        public IssueController(IIssueService issueService, ILogger<IssueController> logger)
        {
            _issueService = issueService;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get(string projectCode)
        {
            try
            {
                //var results = _issueService.GetIssuesByProjectCode(projectCode);

                //return Json(results);
                return Json(null);
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
