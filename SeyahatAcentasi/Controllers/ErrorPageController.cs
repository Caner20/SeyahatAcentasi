using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {

            return View();
        }
    }
}
