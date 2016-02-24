using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace ProjectPlannerASP5.Controllers.Web
{
    [Authorize]
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
