using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SanSoftInfoTech.Models;
using SanSoftInfoTech.Services;
using SanSoftInfoTech.ViewModels;

namespace SanSoftInfoTech.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IInvoicesRepository _invoicesRepository;


        public InvoicesController(IInvoicesRepository invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;
        }


        [HttpGet]
        public IActionResult CreateInvoice()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateInvoice(CreateInvoiceVM invoice)
        {

            return View();
        }

    }
}
