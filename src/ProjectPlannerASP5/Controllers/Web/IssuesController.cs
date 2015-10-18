using Microsoft.AspNet.Mvc;
using ProjectPlannerASP5.ViewModels;
using ProjectPlannerASP5.Services;
using ProjectPlannerASP5.Models;
using System.Linq;

namespace ProjectPlannerASP5.Controllers.Web
{
    public class IssuesController : Controller
    {
        private readonly IIssueService _issueService;
        private readonly IMailService _mailService;
        private readonly AppContext _appContext;

        public IssuesController(IIssueService issueService, AppContext appContext)//, IMailService mailService)
        {
            _issueService = issueService;
            _appContext = appContext;
            //_mailService = mailService;
            //var a = _appContext.Issues.ToList();
        }

        public IActionResult Index()
        {
            var issues = _issueService.GetIssues();

            return View(issues);
        }

        //[Route("Edit/{id}")]
        //[AjaxOnly]
        public PartialViewResult Edit(int id)
        {
            var taskVm = _issueService.GetIssue(id);
            
            @ViewBag.Title = string.Format("Edit task: {{ProjectName}}-{0}", taskVm.IssueNumber);
            @ViewBag.AdditionalInfo = "Here you can edit your task";

            return PartialView("Edit", taskVm);
        }

        [HttpPost]
        public IActionResult Edit(EditIssueViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    _issueService.Insert(viewModel);
                }
                else
                {
                    _issueService.Update(viewModel);
                }

                return RedirectToAction("Index");
            }
            return PartialView("Edit", viewModel);
        }
    }
}
