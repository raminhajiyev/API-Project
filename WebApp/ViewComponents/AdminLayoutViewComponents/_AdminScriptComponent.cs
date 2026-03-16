using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminScriptComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
