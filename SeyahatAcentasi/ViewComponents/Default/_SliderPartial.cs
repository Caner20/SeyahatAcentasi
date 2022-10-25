using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        //ViewComponent lere direk erişim sağlanamıyor
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
