using Microsoft.AspNetCore.Mvc;

namespace FishingLogMVC.Controllers
{
    public class CMSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
