using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.ViewComponents.AdminDashBoard
{
    public class _DashboardBanner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
