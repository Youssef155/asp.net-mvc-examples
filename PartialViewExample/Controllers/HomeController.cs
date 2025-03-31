using Microsoft.AspNetCore.Mvc;

namespace PartialViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["ListTitle"] = "Countries";
            ViewData["ListItems"] = new List<string>()
            {
                "Egypt",
                "UK",
                "USA",
                "France",
                "Japan"
            };


            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
