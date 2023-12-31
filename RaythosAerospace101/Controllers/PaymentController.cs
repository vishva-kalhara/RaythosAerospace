using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaymentController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(string id, double totalPrice, string targetFunctionality)
        {
            ViewBag.id = id;
            ViewBag.totalPrice = totalPrice;
            ViewBag.targetFunctionality = targetFunctionality;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string id, string targetFunctionality, string nameOnCard, string cardNumber, string expDate, string cvv)
        {
            if (HttpContext.Session.GetString("role") != "4" && HttpContext.Session.GetString("role") != "3")
                return RedirectToAction("OnlyUsers", "Messages");

            ViewBag.primaryKey = id;

            if (string.IsNullOrEmpty(nameOnCard))
                ModelState.AddModelError("NameOnCard", "Name on the card can't be empty");
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length != 16)
                ModelState.AddModelError("CardNumber", "Incorrect Card Number");
            if (string.IsNullOrEmpty(expDate))
                ModelState.AddModelError("ExpDate", "Expiery Date Can't be empty");
            if (string.IsNullOrEmpty(cvv))
                ModelState.AddModelError("Cvv", "CVV Can't be empty");

            if (ModelState.IsValid)
            {
                if (targetFunctionality == "Plane")
                    return RedirectToAction("PayForOne", "Plane");
            }

            return View();
        }

        public IActionResult DoPayment(string id, string targetFunctionality, string nameOnCard, string cardNumber, string expDate, string cvv)
        {
            

            return View();
        }
    }
}
