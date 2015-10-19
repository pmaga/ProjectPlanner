using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using ProjectPlannerASP5.Entites;
using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.Services;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectPlannerASP5.Controllers.Api
{
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
        public JsonResult Get(int projectId)
        {
            try
            {
                var results = _issueService.GetIssuesByProjectId(projectId);

                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get issues for project with id: {projectId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured finding the issues");
            }
        }

        public JsonResult Post(string projectCode, [FromBody]EditIssueViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Attempting to saving new issue.");

                    if (_issueService.Insert(projectCode, vm))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(new { id = vm.Id });
                    }
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
