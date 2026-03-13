using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.MenuViewComponents
{
    public class _MenuViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
