using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SanSoftInfoTech.Data;
using SanSoftInfoTech.Models;
using SanSoftInfoTech.Services;
using SanSoftInfoTech.ViewModels;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SanSoftInfoTech.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IInvoicesRepository _invoicesRepository;
		private readonly IUsersRepository _usersRepository;
        

		public InvoicesController(IInvoicesRepository invoicesRepository, IUsersRepository usersRepository)
        {
            _invoicesRepository = invoicesRepository;
            _usersRepository = usersRepository;
		}


        [HttpGet]
        public IActionResult CreateInvoice()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceVM invoice)
        {
            var currentUserId = HttpContext.Session.GetInt32("UserId");
            if(currentUserId == null)
                return RedirectToAction("ErrorPage", "Errors", new { message = "Current User is not found" });

            var currentUser = await _usersRepository.GetUserIdAsync(currentUserId.Value);
            if(currentUser == null)
				return RedirectToAction("ErrorPage", "Errors", new { message = "Current User is not found" });


			//Applay back-end validation on the invoice items
			List<LineItem>? LineItems = null;
            try
            {
                var items = JsonSerializer.Deserialize<List<LineItem>>(invoice.LineItemsJSON);
                LineItems = items;
            }
            catch
            {
                ModelState.AddModelError("LineItemsJSON", "Enter valid input for the invoice items");
            }

            if (!ModelState.IsValid)
                return View(invoice);

            decimal Subtotal = LineItems!.Sum(it => it.TotalPrice);
            decimal Total = Subtotal + invoice.TaxValue;

            var newInvoice = new Invoice
            {
                InvoiceDate = invoice.InvoiceDate,
                DueDate = invoice.DueDate,
                CustomerName = currentUser.UserName!,
                CustomerAddress = invoice.CustomerAddress,
                CustomerEmail = invoice.CustomerEmail,
                CustomerPhone = invoice.CustomerPhone.ToString(),
                Subtotal = Subtotal,
                Taxes = invoice.TaxValue,
                Total = Total,
                Status = invoice.Status,
                LineItems = LineItems,
                UserId = currentUser.UserId
			};

            //Save the newInvoice into the database
            var invoiceNumber = await _invoicesRepository.AddInvoiceToDatabaseAsync(newInvoice);
            TempData["InvoiceAdded"] = "True";

            return RedirectToAction("InvoicePage",new { invoiceNumber = invoiceNumber });
        }

        [HttpGet]
        public async Task<IActionResult> InvoicePage(int invoiceNumber)
        {
            var targetInvoice = await _invoicesRepository.GetInvoiceAsync(invoiceNumber);
            if (targetInvoice == null)
                return RedirectToAction("ErrorPage", "Errors", new { message = "Invoice is not found" });

            return View(targetInvoice);
        }
    }
}
