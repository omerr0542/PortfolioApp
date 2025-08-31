using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using PortfolioApp.Web.Context;
using PortfolioApp.Web.Entities;
using PortfolioApp.Web.Models;
using System.Security.Claims;

namespace PortfolioApp.Web.Controllers
{
    [AllowAnonymous] // Bu controller altındaki action'lara yetkisiz erişime izin ver
    public class AuthController(PortfolioContext context) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Fast Fail: Önce hataları yakala sonra işlemi yap
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = context.Users.FirstOrDefault(u => u.UserName == model.Username && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalıdır!");
                return View();
            }

            var claims = new List<Claim> // Kullanıcı bilgilerini tutan claim'ler. Bu claimlere ulaşmak için User.Identity.Name gibi kullanabiliriz.
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("FullName", string.Join(" ", user.FirstName, user.LastName)),
                new Claim("UserId", user.UserId.ToString())
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authPorperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30), // Oturumun 30 dakika sonra sona ermesi
                IsPersistent = false // Oturumun tarayıcı kapatılsa bile devam etmesi
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authPorperties);

            HttpContext.Session.SetString("UserName", user.UserName); // Oturum bilgilerini session'a kaydet

            return RedirectToAction("Index", "Statistics");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");
        }
    }
}
