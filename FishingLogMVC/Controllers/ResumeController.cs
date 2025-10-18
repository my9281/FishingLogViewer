using Microsoft.AspNetCore.Mvc;

namespace FishingLogMVC.Controllers
{
    public class ResumeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
