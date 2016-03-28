using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace ProjectPlannerASP5.Controllers.Web
{
    [Authorize]
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            var user = (ClaimsIdentity)User.Identity;
            ViewBag.Username = user.Name;

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
