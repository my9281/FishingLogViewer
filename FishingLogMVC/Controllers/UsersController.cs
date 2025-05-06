using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.Data;
using System.Text;
using FishingLogMVC.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using FishingLogMVC.Models;

namespace FishingLogMVC.Controllers
{
    public class UsersController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
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

        private readonly string _secretKey = "ThomasMagicChen_1992";

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

            if (string.IsNullOrEmpty(userId) )
            { 
                return Json( "-1");
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
