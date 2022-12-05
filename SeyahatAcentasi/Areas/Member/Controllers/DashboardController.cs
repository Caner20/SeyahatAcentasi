using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SeyahatAcentasi.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    { 
        private readonly UserManager<AppUser> _userManager;  //UserManager dan Appuser'i cagir 

        public DashboardController(UserManager<AppUser> userManager) //bu sinifin yapici metodunu yazdik
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); //_userm. isme gore buluyor values degiskenine atiyor
            ViewBag.userName = values.Name + " " + values.Surname;  //sayfa da ViewBag. diyerek userName olarak tasiyoruz
            ViewBag.userImage = values.ImageUrl;  //gelen degerin fotografini al
            return View();
        }
    }
}
