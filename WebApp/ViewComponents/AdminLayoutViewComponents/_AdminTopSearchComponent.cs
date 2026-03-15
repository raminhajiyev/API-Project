using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminTopSearchComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
