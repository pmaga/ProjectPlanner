using Microsoft.AspNet.Mvc.Rendering;

namespace ProjectPlannerASP5.Helpers
{
    public static class MenuHelpers
    {
        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null)
        {
            const string cssClass = "active";
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];

            if (string.IsNullOrEmpty(controller))
                controller = currentController;

            if (string.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : string.Empty;
        }
    }
}
