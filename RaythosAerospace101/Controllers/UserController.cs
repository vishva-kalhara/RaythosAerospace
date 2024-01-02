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

        public IActionResult MyProfile()
        {
            if (HttpContext.Session.GetString("email") == null)
                return RedirectToAction("OnlyUsers", "Messages");

            var user = _db.Users.Find(HttpContext.Session.GetString("email"));
            return View(user);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MyProfile(User obj)
        {
            if (obj !=null )
            {
                _db.Update(obj);
                _db.SaveChanges();
            }
            return View();
        }

        public IActionResult Promote(string id)
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyAdmin", "Messages");
            }

            var user = _db.Users.Find(id);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Messages");
            }

            if (user.RoleId == 3)
            {
                user.RoleId = 4;
            }
            else if (user.RoleId == 4)
            {
                user.RoleId = 3;
            }
            else
            {
                return RedirectToAction("UnexpectedError", "Messages");
            }

            _db.Users.Update(user);
            _db.SaveChanges();
            return RedirectToAction("UserList", "Admin");
        }
        
        public IActionResult Block(string id)
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyAdmin", "Messages");
            }

            var user = _db.Users.Find(id);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Messages");
            }

            if (user.UsrStatusId == 1)
            {
                user.UsrStatusId = 3;
            }
            else if (user.UsrStatusId == 3)
            {
                user.UsrStatusId = 1;
            }
            else
            {
                return RedirectToAction("UnexpectedError", "Messages");
            }

            _db.Users.Update(user);
            _db.SaveChanges();
            return RedirectToAction("UserList", "Admin");
        }

        public IActionResult SignOut101()
        {
            if (HttpContext.Session.GetString("role") != "4" && HttpContext.Session.GetString("role") != "3")
            {
                return RedirectToAction("OnlyUsers", "Messages");
            }
            HttpContext.Session.SetString("email", "");
            HttpContext.Session.SetString("role", "");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UsersList()
        {
            if (HttpContext.Session.GetString("role") != "4")
                return RedirectToAction("OnlyAdmin", "Messages");

            IEnumerable<User> objList = _db.Users;
            return View(objList);
        }
       


    }
}
