using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Controllers
{
    public class MessagesController : Controller
    {
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
    }
}
