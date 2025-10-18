using Microsoft.AspNetCore.Mvc;

namespace FishingLogMVC.Controllers
{
    public class YmcuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
