using Microsoft.AspNetCore.Mvc;

namespace SeyahatAcentasi.ViewComponents.AdminDashBoard
{
    public class _AdminDashboardHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
