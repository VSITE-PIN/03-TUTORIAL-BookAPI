using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
