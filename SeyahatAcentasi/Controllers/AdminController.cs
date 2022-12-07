using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }
        public PartialViewResult PartialAppBrandDemo()
        {
            return PartialView();
        }
    }
}
