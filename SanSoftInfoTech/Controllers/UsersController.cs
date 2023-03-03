using Microsoft.AspNetCore.Mvc;
using SanSoftInfoTech.Data;
using SanSoftInfoTech.Models;
using SanSoftInfoTech.Services;
using SanSoftInfoTech.ViewModels;

namespace SanSoftInfoTech.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;


        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        [HttpGet]
        public async Task<IActionResult> LogIn(string? userName,string? password)
        {
            if(userName != null && password != null)
            {
                var targetUser = await _usersRepository.GetUserAsync(userName, password);
                if (targetUser == null)
                    return RedirectToAction("ErrorPage", "Errors", new { message = "User is not found" });

                HttpContext.Session.SetInt32("UserId", targetUser.UserId);

                return RedirectToAction("Profile", "Profiles");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInVM VM)
        {
            if(!ModelState.IsValid)
                return View(VM);

            var targetUser = await _usersRepository.GetUserAsync(VM.UserName, VM.Password);
            if (targetUser == null)
                return RedirectToAction("ErrorPage", "Errors", new { message = "User is not found" });

			HttpContext.Session.SetInt32("UserId", targetUser.UserId);


			return RedirectToAction("Profile", "Profiles");
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserId");

            return RedirectToAction("LogIn");
		}

        [HttpGet]
        public IActionResult Register() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User newUser)
        {
            //Validate the name and password combination
            var usersWithASameName = _usersRepository.GetUsersByName(newUser.UserName).ToList();
            if(usersWithASameName != null && usersWithASameName.Count > 0)
            {
                foreach(var user in usersWithASameName)
                {
                    if(user.Password == newUser.Password)
                    {
                        ModelState.AddModelError("password", "This name is already taken");
                        break;
                    }
                }
            }

            if (!ModelState.IsValid)
                return View(newUser);
            
            //Here everything is valid and we can save the user in the database
            await _usersRepository.AddUserAsync(newUser);

            return RedirectToAction("LogIn",new { userName = newUser.UserName, password = newUser.Password});
        }

    }
}