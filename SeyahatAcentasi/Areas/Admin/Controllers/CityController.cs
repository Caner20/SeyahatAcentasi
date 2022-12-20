using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeyahatAcentasi.Models;
using System.Collections.Generic;

namespace SeyahatAcentasi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()   //ajax isleminde ındex sadece sayfa goruntusu icin kullanilicak
        {
            return View();
        }

        public IActionResult CityList()  //boyle oldugu icin listeleye tıkladıgımızda sayfa yenilenmeden direk veriler gelicek
        {//listelemek icin SerializeObject yaptik cities den gelen degerleri
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());   //tgetlist ile ilgili verileri getir
            return Json(jsonCity);   //json olarak geri dondurduk
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination); //girilen parametreyi ekledik
            var values = JsonConvert.SerializeObject(destination);  //destination dan gelen degeri json dondur ve values atadik
            return Json(values);  //json forrmatına donusturup values degerini dondurduk
        }


        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.GetTByID(DestinationID); //destinationid ye gore ilgili degiskeni bul
            var jsonValues = JsonConvert.SerializeObject(values); //gelen values ' i donusum yaptık
            return Json(jsonValues);        //donusen veriyi json olarak return yap
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.GetTByID(id);   //id ye gore bul
            _destinationService.TDelete(values);            //bulunun degeri sil
            return NoContent();   //hiçbir sey dondurmemesi icin
        }

        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);  //gelen degeri guncelle
            var v = JsonConvert.SerializeObject(destination);  //serial bir şekilde dizi jsona donusturduk
            return Json(v);
        }






    }
}
