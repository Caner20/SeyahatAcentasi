using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.ViewComponents.Default
{
    public class _StatisticsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // ViewBag ....  ViewBag veri yazdırma 
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count(); //c nesnesine rotaları say
            ViewBag.v2 = c.Guides.Count();
            ViewBag.v3 = "352";
            return View();
        }
    }
}
