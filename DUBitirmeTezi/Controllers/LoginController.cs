using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUBitirmeTezi.DbData;
using DUBitirmeTezi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace DUBitirmeTezi.Controllers
{
    public class LoginController : Controller
    {
        private readonly DUBitirmeTeziDbContext _context;

        public LoginController(DUBitirmeTeziDbContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GirisYap(YetkiliGirisi yetkiliGirisi)
        {
            var bilgiler = _context.YetkiliGirisis.FirstOrDefault(x => x.KullaniciAdi == yetkiliGirisi.KullaniciAdi && x.Sifre == yetkiliGirisi.Sifre);

            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, yetkiliGirisi.KullaniciAdi)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("AdminPanel", "Home");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
