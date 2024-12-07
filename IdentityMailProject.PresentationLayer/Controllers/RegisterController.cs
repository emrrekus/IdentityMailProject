using IdentityMailProject.EntityLayer.Concrete;
using IdentityMailProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMailProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
          
            if (!ModelState.IsValid)
            {
                return View(model);
            }

          
            AppUser appUser = new AppUser
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.UserName,
                
            };

           
            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                
                return RedirectToAction("Index", "Login");
            }

            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

         
            return View(model);
        }

    }
}
