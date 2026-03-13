using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class _FeatureDefaultComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
