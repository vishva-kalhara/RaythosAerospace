using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaythosAerospace101.Data;
using RaythosAerospace101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View();
        }
        
        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User inData)
        {
            IEnumerable<User> objList = _db.Users;
            foreach (var item in objList)
            {
                if(item.Email != inData.Email || item.Password != inData.Password)
                {
                    ModelState.AddModelError("LoginError", "Username and Password do not match.");
                }
                else
                {
                    HttpContext.Session.SetString("email", item.Email);
                    HttpContext.Session.SetString("role", item.RoleId.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        
        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User obj, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                if(obj.Password != confirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "The password and confirm password do not match.");
                    return View();
                }

                obj.RoleId = 3;
                obj.UsrStatusId = 1;
                _db.Users.Add(obj);
                _db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
