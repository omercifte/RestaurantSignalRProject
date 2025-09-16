using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.DefaultComponents
{
    public class _DefaultAboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
