using Entities;
using furns.viewmodel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using System.Security.Claims;
using System.Xml.Linq;

namespace furns.Controllers
{
    public class AuthController : Controller
    {

        private readonly RegisService _reg;
        public AuthController(RegisService reg)
        {
            _reg = reg;
        }


        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginVM model)
        {
            if (model == null) NotFound();

            Fuser item = _reg.getUser(model.FullName, model.Password);
            if (item != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,item.FullName),
                        new Claim(ClaimTypes.Role,item.Role)
                      
                    };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), (authProperties));
                return RedirectToAction("Index","Home");
            }

            return View();

        }

       
        public IActionResult Regis()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Regis(Fuser model)
        {
                if (model == null) return NotFound();
            model.Image = "sdvsvsd";
                _reg.adduser(model);
                return RedirectToAction("login");
        }
    }
}
