using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.AdminLayoutViewComponents
{
    public class _HeadAdminComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
