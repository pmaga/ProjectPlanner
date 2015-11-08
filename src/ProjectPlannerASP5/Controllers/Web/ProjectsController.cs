using Microsoft.AspNet.Mvc;

namespace ProjectPlannerASP5.Controllers.Web
{
    //[Authorize]
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
