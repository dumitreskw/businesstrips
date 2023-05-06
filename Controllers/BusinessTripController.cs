using Microsoft.AspNetCore.Mvc;

namespace BusinessTrips.Controllers
{
    public class BusinessTripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
