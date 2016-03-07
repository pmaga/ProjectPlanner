using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace ProjectPlannerASP5.Controllers.Web
{
    [Authorize]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        public ProjectsController()
        {
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]/{id}")]
        public IActionResult Details(int id)
        {
            return View(id);
        }

        [Route("[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            return View(id);
        }
    }
}
