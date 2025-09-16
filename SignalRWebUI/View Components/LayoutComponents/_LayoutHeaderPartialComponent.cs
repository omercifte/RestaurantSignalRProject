using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.LayoutComponents
{
    public class _LayoutHeaderPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
