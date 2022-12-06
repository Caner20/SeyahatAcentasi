using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.ViewComponents.MemberDashBoard
{
    public class _PlatformSetting : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            return View();
        }
    }
}
