using Microsoft.AspNetCore.Mvc;

namespace IdentityMailProject.PresentationLayer.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
