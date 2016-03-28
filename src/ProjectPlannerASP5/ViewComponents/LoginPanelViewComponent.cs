using Microsoft.AspNet.Mvc;

namespace ProjectPlannerASP5.ViewComponents
{
    public class LoginPanelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("_LoginPanelAuthenticated");
            }
            else
            {
                return View("_LoginPanelAnonymous");
            }
        }
    }
}
