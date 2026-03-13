using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class _AboutDefaultComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
