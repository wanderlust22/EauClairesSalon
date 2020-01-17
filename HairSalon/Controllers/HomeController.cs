using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}