using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SeyahatAcentasi.ViewComponents.AdminDashBoard
{
    public class _Cards1Statistic : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Destinations.Count(); //Rotaların sayisini getir viewbag v1' e attik
            ViewBag.v2 = c.Users.Count(); //Kullanicilarin sayisini getir v2 ye at
            return View();
        }
    }
}
