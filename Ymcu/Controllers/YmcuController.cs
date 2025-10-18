using Microsoft.AspNetCore.Mvc;

namespace Ymcu.Controllers
{
    public class YmcuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
