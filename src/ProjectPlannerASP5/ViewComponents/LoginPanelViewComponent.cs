using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
