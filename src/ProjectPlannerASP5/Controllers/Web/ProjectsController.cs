using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using ProjectPlannerASP5.Services;

namespace ProjectPlannerASP5.Controllers.Web
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectsService;

        public ProjectsController(IProjectService projectsService)
        {
            _projectsService = projectsService;
        }

        public IActionResult Index()
        {
            var projects = _projectsService.GetProjects(User.Identity.Name);

            return View(projects);
        }
    }
}
