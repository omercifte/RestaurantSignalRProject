using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.LayoutComponents
{
    public class _LayoutNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
