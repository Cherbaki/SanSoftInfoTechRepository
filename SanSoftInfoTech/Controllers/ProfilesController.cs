using Microsoft.AspNetCore.Mvc;
using SanSoftInfoTech.Data;
using SanSoftInfoTech.Repositories;
using SanSoftInfoTech.Services;
using SanSoftInfoTech.ViewModels;

namespace SanSoftInfoTech.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IInvoicesRepository _invoicesRepository;
		private readonly IUsersRepository _usersRepository;


		public ProfilesController(IInvoicesRepository invoicesRepository, IUsersRepository usersRepository)
        {
            _invoicesRepository = invoicesRepository;
            _usersRepository = usersRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Profile()
        {
			var currentUserId = HttpContext.Session.GetInt32("UserId");
			if (currentUserId == null)
				return RedirectToAction("ErrorPage", "Errors", new { message = "Current User is not found" });

			var currentUser = await _usersRepository.GetUserIdAsync(currentUserId.Value);
			if (currentUser == null)
				return RedirectToAction("ErrorPage", "Errors", new { message = "Current User is not found" });

            var VM = new ProfileVM
            {
                CurrentUser = currentUser,
                MiniInvoiceVMs = _invoicesRepository.GetUsersInvoices(currentUser.UserId)?.ToList()
            };


            return View(VM);
        }



    }
}
