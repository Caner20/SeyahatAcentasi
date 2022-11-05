using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        public IActionResult MyCurrentReservation()  //aktif rezervasyon
        {

            return View();
        }

        public IActionResult MyOldReservation()     //pasif rezervasyon
        {
            return View();
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
