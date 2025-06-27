using FishingLogMVC.Interfaces;
using FishingLogMVC.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace FishingLogMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsApiController : ControllerBase
    {
        private readonly INoSQLDB<LogsApiController> _db;

        public LogsApiController(INoSQLDB<LogsApiController> db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var logs = _db.GetDB().GetCollection<Loginfo>("logs").Find(Query.All()).ToList();
            return Ok(logs);
        }
    }
}
