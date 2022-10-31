using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyahatAcentasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.Controllers
{
    [AllowAnonymous] //altında bulundugu ne varsa gecerli butun kurallardan muaf haline getiriyor
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()  //AppUser den appUser nesnesi ürettik  altaki özellikleri verdik p parametresinden gelen degeri atadik
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username,
            };
            if (p.Password == p.ConfirmPassword)    //parametreden gelen şifre , tekrar edilen sifreye esitse
            {
                var result = await _userManager.CreateAsync(appUser, p.Password); //sifreyi create asenkronik metotla aldık  çünkü sifre arka tarafta hash'lenerek(sifrelenerek) gelicek

                if (result.Succeeded) //result basariliysa
                {
                    return RedirectToAction("SignIn");  //redirec aksiyonu if true basarili ise SignIn yönlendir
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description); //error olarak item den gelen aciklamayi ver
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
