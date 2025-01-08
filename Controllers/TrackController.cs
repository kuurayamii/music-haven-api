using Microsoft.AspNetCore.Mvc;

namespace MusicHaven.Controllers
{
    public class TrackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
