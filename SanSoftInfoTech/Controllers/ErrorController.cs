using Microsoft.AspNetCore.Mvc;
using SanSoftInfoTech.ViewModels;

namespace SanSoftInfoTech.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage(string message)
        {
            var VM = new ErrorPageVM { Message = message };
            
            return View(VM);
        }
    }
}
