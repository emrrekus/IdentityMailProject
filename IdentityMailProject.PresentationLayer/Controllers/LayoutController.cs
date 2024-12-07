using Microsoft.AspNetCore.Mvc;

namespace IdentityMailProject.PresentationLayer.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
