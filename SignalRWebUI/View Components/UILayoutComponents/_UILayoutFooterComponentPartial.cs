using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
