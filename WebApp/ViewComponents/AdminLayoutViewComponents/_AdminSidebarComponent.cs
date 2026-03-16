using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminSidebarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
