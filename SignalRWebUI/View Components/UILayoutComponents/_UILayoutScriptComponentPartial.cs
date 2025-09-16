using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.UILayoutComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
