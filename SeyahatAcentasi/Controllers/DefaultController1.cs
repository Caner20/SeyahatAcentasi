using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.Controllers
{
    public class DefaultController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
