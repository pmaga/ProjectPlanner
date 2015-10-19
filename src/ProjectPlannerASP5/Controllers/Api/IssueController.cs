using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using ProjectPlannerASP5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectPlannerASP5.Controllers.Api
{
    [Route("api/projects/{projectId}/issues")]
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
        public JsonResult Get(int projectId)
        {
            try
            {
                var results = _issueService.GetIssuesByProjectId(projectId);

                return Json(results.OrderBy(issue => issue.CreateDate));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get issues for project with id: {projectId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured finding the issues");
            }
        }
    }
}
