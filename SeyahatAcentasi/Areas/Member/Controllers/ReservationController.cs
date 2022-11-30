using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _userManager;  //bu islem ilk once kullanici bilgilerini almak icin

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()  //aktif rezervasyon
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);    //kullaniciyi adina gore bul
            var valuesList = reservationManager.GetListWithReservationByAccepted(values.Id); //values den id degere gore listele 
            return View(valuesList);
        }

        public async Task<IActionResult> MyOldReservation()     //pasif rezervasyon
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);    //kullaniciyi adina gore bul
            var valuesList = reservationManager.GetListWithReservationByPrevious(values.Id); //values den id degere gore listele 
            return View(valuesList);
        }

        //degiskene await dendigi zaman property asenkronik olmalıdır
        public async Task<IActionResult> MyApprovalReservation()        //ONAY bekleyen rezervasyon
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);    //kullaniciyi adina gore bul
            var valuesList = reservationManager.GetListWithReservationByWaitApproval(values.Id); //values den id degere gore listele 
            return View(valuesList);  //valuesList'ten gelen degerleri dondur
        }


        [HttpGet]
        public IActionResult NewReservation()    //yeni rezervasyon
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()  //destinationmanagerdan verileri liste olarak seciyoruz
                                           select new SelectListItem
                                           {
                                               Text=x.Cİty,
                                               Value=x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = 4;
            p.Status = "Onay Bekliyor";
            reservationManager.TAdd(p);     //p parametresi ile eklendi
            return RedirectToAction("MyCurrentReservation");  //MyCurrentReservation yonlendirdik
        }
    }
}
