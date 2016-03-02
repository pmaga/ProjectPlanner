using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

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

        public IActionResult Details(int id)
        {
            return View(id);
        }

        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
