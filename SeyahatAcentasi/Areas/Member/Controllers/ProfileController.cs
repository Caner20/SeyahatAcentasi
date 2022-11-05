using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyahatAcentasi.Areas.Member.Models;
using System;
using System.Collections.Generic;
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
            var values = await _userManager.FindByNameAsync(User.Identity.Name);        //isme göre arayacak kullanicinin identity'sine göre Name i bul
            UserEditViewModel userEditViewModel = new UserEditViewModel();  //UserEditViewModel den nesne ürettik
            userEditViewModel.name=values.Name;  //userEditViewModel name degeri values den gelen Name degerine esitle
            userEditViewModel.surname = values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.mail = values.Email;
            return View(userEditViewModel);
        }
    }
}
