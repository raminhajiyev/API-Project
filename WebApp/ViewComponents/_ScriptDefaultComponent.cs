using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class _ScriptDefaultComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
