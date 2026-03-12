using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class _HeaderDefaultComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
