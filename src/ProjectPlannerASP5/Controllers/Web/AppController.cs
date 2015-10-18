using Microsoft.AspNet.Mvc;

namespace ProjectPlannerASP5.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Configuration()
        {
            var configEmail = Startup.Configuration["AppSettings:SiteEmailAddress"];

            return View();
        }
    }
}
