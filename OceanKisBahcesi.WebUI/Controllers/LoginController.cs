using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (_userService.CheckUser(userLoginModel.Username, userLoginModel.Password))
                {
                    var claims = new List<Claim>
{
    new Claim(ClaimTypes.Name, userLoginModel.Username),
    new Claim(ClaimTypes.Role, "Admin"),
};

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToAction("SubProductList", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı");
                }
            }
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction("Index", "Login");
        }
    }
}
