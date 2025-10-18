using Microsoft.AspNetCore.Mvc;

namespace FishingLogMVC.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
