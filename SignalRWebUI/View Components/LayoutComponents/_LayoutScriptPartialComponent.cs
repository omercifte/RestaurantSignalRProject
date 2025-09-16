using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.LayoutComponents
{
    public class _LayoutScriptPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
