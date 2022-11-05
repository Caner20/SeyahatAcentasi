using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyahatAcentasi.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]  //yazilmasi gerekli bir rota yoksa sayfa goruntulenmiyor
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;  //UserManager dan Appuser'i cagir 

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);        //isme göre arayacak kullanicinin identity'den gelen Name i bul
            UserEditViewModel userEditViewModel = new UserEditViewModel();  //UserEditViewModel den nesne ürettik
            userEditViewModel.name=values.Name;  //userEditViewModel name degeri values den gelen Name degerine esitle
            userEditViewModel.surname = values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.mail = values.Email;
            return View(userEditViewModel);
        }

        [HttpPost]    //post ile kullanicilar kendi bilgilerini guncelleyebilicek
        public async Task<IActionResult> Index(UserEditViewModel p) 
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)        //parametreden gelen image degeri null a esit degilse
            {
                var resource = Directory.GetCurrentDirectory();  //sistem IO dan komutlar  erisimi aktif ettik
                var extesion = Path.GetExtension(p.Image.FileName);   //parametreden gelen image ve dosya ismi
                var imagename = Guid.NewGuid() + extesion;    //image ismini newguide olarak tut ve uzantı olarak ekle
                var savelocation = resource + "/wwwroot/Userimages/" + imagename;
                var stream = new FileStream(savelocation,FileMode.Create);  //dosya icerigi olarak aktarim yaptik
                await p.Image.CopyToAsync(stream);   //p den gelen image'i akisa kopyala
                user.ImageUrl = imagename;  //sisteme otantike olan kullanıcı nın imageurl sini imagename den gelen deger atandi
            }
            user.Name = p.name;
            user.Surname = p.surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password); //sifre güncelleme islemi
            var result = await _userManager.UpdateAsync(user);  //user dan gelen degeri gunceleme yapicak
            if (result.Succeeded)  // result degeri basariliysa
            {
                return RedirectToAction("SignIn","Login"); //login de olan SignIn e yonlendirdik
            }
            return View();
        }
    }
}
