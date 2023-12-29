using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessagesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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

        public IActionResult NotFound()
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
            {
                return RedirectToAction("OnlyUsers", "Messages");
            }
            return View();
        }
    }
}
