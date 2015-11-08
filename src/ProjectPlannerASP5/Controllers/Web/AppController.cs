using Microsoft.AspNet.Mvc;
using ProjectPlanner.Cqrs.Base.DDD.Application;

namespace ProjectPlannerASP5.Controllers.Web
{
    //[Authorize]
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
