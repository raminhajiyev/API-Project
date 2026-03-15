using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
