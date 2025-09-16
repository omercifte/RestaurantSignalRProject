using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.View_Components.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
