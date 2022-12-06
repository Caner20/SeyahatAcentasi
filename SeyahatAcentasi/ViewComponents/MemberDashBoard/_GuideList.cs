using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.ViewComponents.MemberDashBoard
{
    public class _GuideList : ViewComponent
    {
        GuideManager guideManager = new GuideManager(new EfGuideDal());  
        public IViewComponentResult Invoke(int id)
        {
            var values = guideManager.TGetList();  //guideM. 'daki bilgileri getlist()'le dondurduk  
            return View(values);
        }
    }
}
