using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
