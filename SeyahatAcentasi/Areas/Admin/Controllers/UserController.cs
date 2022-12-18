using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService appUserService;
        private readonly IReservationService _reservationService;
        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            this.appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = appUserService.TGetList();
            return View(values);
        }

        public IActionResult UserDeleteUser(int id)
        {
            var values = appUserService.GetTByID(id);  //id ye gore veriyi bul
            appUserService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]    //veriyi getirme islemi icin kullanilicak alttaki kodlar
        public IActionResult EditUser(int id)
        {
            var values = appUserService.GetTByID(id);   // id ye gore bul
            return View(values);                        //degeri dondur
            
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            appUserService.TGetList();
            return View();
        }

        public IActionResult ReservationUser(int id)
        {
            var values= _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
