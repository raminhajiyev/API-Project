using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminSettingSidebarComponent:ViewComponent                                        
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
