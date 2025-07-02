using FishingLogMVC.Core;
using FishingLogMVC.Interfaces;
using FishingLogMVC.Middlewares;
using FishingLogMVC.Models;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace FishingLogMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly WebSocketConnectionManager _wsManager;
        private readonly INoSQLDB<HomeController> _db;
        private readonly ICookiesService<HomeController> _cookies;

        public HomeController(INoSQLDB<HomeController> db, ICookiesService<HomeController> cookies, WebSocketConnectionManager wsManager)
        {
            _wsManager = wsManager; 
            _db = db;
            _cookies = cookies;
        }

        public IActionResult Index()
        {
            var p0 = _cookies.GetUserLanguage();
            var c = _db.GetDB().GetCollection<Loginfo>("logs").Find(Query.All()).Where(ex => ex.Updatetime != null).OrderBy(ex => DateTime.Parse(
                Regex.Replace(ex.Updatetime.Split(new string[] { "\r\n", "~" }, StringSplitOptions.TrimEntries).First(), @"[^0-9\-/]", ""))).ToList();
            ViewBag.Path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return View(c);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
