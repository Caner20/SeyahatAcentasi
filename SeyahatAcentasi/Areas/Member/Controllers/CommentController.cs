using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        [Area("Member")]    //web browser da hata vermemesi icin yazilmasi gerek
        [AllowAnonymous]    //butun kurallardan muaf tut 
        public IActionResult Index()
        {
            return View();
        }
    }
}
