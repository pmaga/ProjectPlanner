using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using ProjectPlannerASP5.Services;

namespace ProjectPlannerASP5.Controllers.Web
{
    [Authorize]
    public class ProjectsController : Controller
    {
        public ProjectsController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
