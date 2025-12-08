using FishingLog.Model;
using FishingLogMVC.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FishingLogMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly string _controlled;
        private readonly string _secretKey = "ThomasMagicChen_1992";
        private readonly WebSocketConnectionManager _wsManager;
        private static readonly FishingLog.BLL.user _userService = new();
        public UsersController(WebSocketConnectionManager wsManager)
        {
            _controlled = Guid.NewGuid().ToString();
            _wsManager = wsManager;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Regist()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/users/login");
            }

            var userModel = _userService.GetModel(userId);
            if (userModel == null)
            {
                return Redirect("/users/login");
            }

            var profile = new FishingLogMVC.Models.ProfileViewModel
            {
                Username = userModel.username ?? string.Empty,
                Nickname = userModel.nickname ?? string.Empty,
                Location = userModel.location ?? string.Empty,
                Birthday = userModel.birthday.ToString("yyyy-MM-dd")
            };

            return View(profile);
        }

        [AllowAnonymous] 
        [HttpPost("/api/Users/RegistData")]
        public async Task<IActionResult> RegistData(user id)
        {
            id.nickname = id.username;
            id.birthday = DateTime.Now;
            id.isadmin = false;

            var userId = DBPassword.Regist(id);
            return Json(userId);
        }
        [AllowAnonymous]
        [HttpGet("Loginbyqr")]
        [HttpGet("/api/Users/Loginbyqr")]
        public async Task<IActionResult> Loginbyqr(string id)
        {
            _wsManager.Accept(id);
            return Json("扫码成功");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/users/login");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost("login")]
        [HttpPost("/api/Users/LoginById")]
        public async Task<IActionResult> LoginById(string Id)
        {
            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Id))
            {
                return Json("-1");
            }
            var userId = DBPassword.Login("Guest", "guest");

            if (string.IsNullOrEmpty(userId))
            {
                return Json("-1");
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userId),
        new Claim(ClaimTypes.Name, Id)
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return Json(userId);
        }

        [Authorize]
        [HttpPost("/api/Users/Profile")]
        public IActionResult UpdateProfile([FromForm] FishingLogMVC.Models.ProfileViewModel profile)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var userModel = _userService.GetModel(userId);
            if (userModel == null)
            {
                return NotFound();
            }

            userModel.nickname = profile.Nickname;
            userModel.location = profile.Location;

            if (DateTime.TryParse(profile.Birthday, out var birthDay))
            {
                userModel.birthday = birthDay;
            }

            var result = _userService.Update(userModel);

            return Json(new { success = result });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [HttpPost("/api/Users/Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Json("-1");
            }
            var userId = DBPassword.Login(username, password);

            if (string.IsNullOrEmpty(userId))
            {
                return Json("-1");
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userId),
        new Claim(ClaimTypes.Name, username)
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return Json(userId);
        }


    }
}
