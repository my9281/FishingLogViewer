using FishingLogMVC.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FishingLog.Model;

namespace FishingLogMVC.Controllers
{
    public class CMSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost("/api/CMS/AddNote")]
        public async Task<IActionResult> AddNote(note content)
        {
            content.ntime = DateTime.Now;
            string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            content.nip = ip;
            var text = DBNote.AddNote(content);
            return Json(text);
        }
        public IActionResult Note()
        {
            return View();
        }


        [Authorize]
        public IActionResult Admin()
        {
            ViewBag.Count = DBNote.GetAllCount();
            ViewBag.datalist= DBNote.GetTopContents();
            return View();
        }
    }
}
