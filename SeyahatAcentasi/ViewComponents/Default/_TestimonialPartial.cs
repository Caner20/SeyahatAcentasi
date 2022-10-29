using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyahatAcentasi.ViewComponents.Default
{
    public class _TestimonialPartial : ViewComponent
    {
        TestimonialManager tm = new TestimonialManager(new EfTestimonialDal());
        
        public IViewComponentResult Invoke() 
        {
            var values = tm.TGetList();
            return View(values);
        }
    }
}
