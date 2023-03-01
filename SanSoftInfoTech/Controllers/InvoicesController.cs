using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
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
                CustomerName = invoice.CustomerName,
                CustomerAddress = invoice.CustomerAddress,
                CustomerEmail = invoice.CustomerEmail,
                CustomerPhone = invoice.CustomerPhone.ToString(),
                Subtotal = Subtotal,
                Taxes = invoice.TaxValue,
                Total = Total,
                Status = invoice.Status,
                LineItems = LineItems
            };

            //Save the newInvoice into the database
            _invoicesRepository.AddInvoiceToDatabase(newInvoice);
            TempData["InvoiceAdded"] = "True";

            return RedirectToAction("Profile", "Profiles");
        }

    }
}
