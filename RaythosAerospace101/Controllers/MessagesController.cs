using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaythosAerospace101.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _db;

        public MessagesController(IHttpContextAccessor httpContextAccessor, ApplicationDbContext db)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        // GET: Success
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OnlyAdmin()
        {
            return View();
        }

        public IActionResult OnlyUsers()
        {
            return View();
        }

        public IActionResult NotFound101()
        {
            return View();
        }

        public IActionResult UnexpectedError()
        {
            return View();
        }

        public IActionResult AlreadyDeleted()
        {
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("role") != "4" && HttpContext.Session.GetString("role") != "3")
                return RedirectToAction("OnlyUsers", "Messages");
          
            return View();
        }

        public IActionResult AddedToCart(int id)
        {
            if (HttpContext.Session.GetString("role") != "4" && HttpContext.Session.GetString("role") != "3")
                return RedirectToAction("OnlyUsers", "Messages");
           
            if(id == 0)
                return RedirectToAction("NotFound101", "Messages");

            var sparePart = _db.SpareParts.Find(id);
            if (sparePart == null || sparePart.Stat != "Active")
                return RedirectToAction("NotFound101", "Messages");

            return View(sparePart);
        }
        
        

        public IActionResult MakePayment(string id, double totalPrice, string targetFunctionality)
        {
            //if (HttpContext.Session.GetString("role") != "4" && HttpContext.Session.GetString("role") != "3")
            //    return RedirectToAction("OnlyUsers", "Messages");

            //if(id == 0)
            //    return RedirectToAction("NotFound", "Messages");

            //var sparePart = _db.SpareParts.Find(id);
            //if (sparePart == null || sparePart.Stat != "Active")
            //    return RedirectToAction("NotFound", "Messages");

            ViewBag.id = id;
            ViewBag.totalPrice = totalPrice;
            ViewBag.targetFunctionality = targetFunctionality;
            return View();
        }
    }
}
