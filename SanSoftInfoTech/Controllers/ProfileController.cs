using Microsoft.AspNetCore.Mvc;
using SanSoftInfoTech.Data;
using SanSoftInfoTech.ViewModels;

namespace SanSoftInfoTech.Controllers
{
    public class ProfileController : Controller
    {

        public IActionResult Profile()
        {
            var currentUser = ProfileInfo.CurrentUser;
            if(currentUser == null)
                return RedirectToAction("ErrorPage", "Error", new { message = "User is not found" });

            var VM = new ProfileVM
            {
                CurrentUser = currentUser
            };
            

            return View(VM);
        }

    }
}
