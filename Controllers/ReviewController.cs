using Microsoft.AspNetCore.Mvc;

namespace MusicHaven.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View('s');
        }
    }
}
