using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class _TopNavbarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
