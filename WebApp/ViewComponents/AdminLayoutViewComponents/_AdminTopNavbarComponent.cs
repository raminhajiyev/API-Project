using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminTopNavbarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
