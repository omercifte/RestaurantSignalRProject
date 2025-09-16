using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
