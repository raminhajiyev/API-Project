using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class _FooterDefaultComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
