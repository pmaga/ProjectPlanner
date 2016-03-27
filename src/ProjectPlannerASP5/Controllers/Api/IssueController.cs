using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ProjectPlanner.Cqrs.Base.CQRS.Commands;
using ProjectPlannerASP5.Services;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Linq;
using System.Net;
using ProjectPlanner.Projects.Domain.Interfaces;
using ProjectPlanner.Projects.Interfaces.Application.Commands;
using ProjectPlanner.Projects.Interfaces.Presentation;

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
        public JsonResult GetAll(string projectCode)
        {
            try
            {
                var results = _issueFinder.FindIssues(projectCode).ToList();

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
        public JsonResult Create(string projectCode, [FromBody]EditIssueViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Attempting to saving a new issue for project: {projectCode}");

                    var createIssueCommand = new CreateIssueCommand(projectCode, vm.Summary, vm.Description, vm.DueDate);
                    _gate.Dispatch(createIssueCommand);
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(new { id = createIssueCommand.IssueId });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new issue", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpPut("")]
        public JsonResult Update(string projectCode, [FromBody]EditIssueViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Attempting to updating issue: {vm.IssueNumber}.");

                    //var changeProjectInformationCommand = new ChangeProjectInformationCommand(vm.Id, vm.Code, vm.Name, vm.Description);
                    //_gate.Dispatch(changeProjectInformationCommand);
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to update issue information", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id, string projectCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Attempting to delete a issue with id: {id}.");

                    //var deleteProjectCommand = new DeleteIssueCommand(id);
                    //_gate.Dispatch(deleteProjectCommand);
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json("");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete issue", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
