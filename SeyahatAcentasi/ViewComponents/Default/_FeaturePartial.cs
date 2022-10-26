using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.ViewComponents.Default
{
    public class _FeaturePartial : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal()); //içerisine EfFeatureDal alan bir FeatureManager nesnesi

        public IViewComponentResult Invoke()
        {
            //var values = featureManager.TGetList(); // bunla veri aktarsaydik 5 tane foreach yapicaktik saglıklı degil
            //ViewBag lerle veri taşıyoruz 
            //ViewBag.image1 = featureManager.GetTByID
            return View();
        }
    }
}
