using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")] //islemelr yapıldıgında gene routeta belirtilen sayfa'da kalmasi icin
    public class GuideController : Controller
    {
       
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            this._guideService = guideService;
        }
        [Route("")]
        [Route("Index")] //Index'in yonlendirme yolu
        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [Route("AddGuide")]  //AddGuide sayfasina yonlendirdik
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result=validationRules.Validate(guide);   //girilen parammetreyi kurallara gore denetle result'a ata
            if(result.IsValid) //eger islem basariliysa ekleme islemini yap
            { 
            _guideService.TAdd(guide);
            return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);  //hangisinin hata ve hata mesajini gosterildi
                }
                return View();
            }
        }


        [Route("EditGuide")]
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.GetTByID(id);
            return View(values);
        }

        [Route("EditGuide")]
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }
        [Route("ChangeToTrue/{id}")]  //id link ki gonderdik

        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index" , "Guide" ,new {area ="Admin"}); //area atamasi yapildi
        }
        [Route("ChangeToFalse/{id}")]

        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }


    }
}
