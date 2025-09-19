using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.MenuComponents
{
    public class _MenuNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
