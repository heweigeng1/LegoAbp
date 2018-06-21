using Microsoft.AspNetCore.Mvc;

namespace LegoAbp.Web.Controllers
{
    public class HomeController : LegoAbpControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}