using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaythosAerospace101.Data;
using RaythosAerospace101.Models;
using RaythosAerospace101.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _db;

        public AdminController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Planes()
        {
            IEnumerable<Plane> objList = _db.Planes;
            return View(objList);
        }
        
        public IActionResult AeroplaneOrders()
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyUsers", "Messages");
            }
            IEnumerable<CustomizedPlane> objList = _db.CustomizedPlanes
                    .Include(cp => cp.Plane)
                    .Include(cp => cp.OverallStatus)
                    .Include(cp => cp.PlaneDesignScheme)
                    .Include(cp => cp.FloorPlan)
                    .Where(cp => cp.IsBasket == false)
                    .Where(cp => cp.OverallStatusId > 1)
                    .ToList();
            return View(objList);
        }

        public IActionResult FinishStage(int id)
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyUsers", "Messages");
            }
            var currObj = _db.CustomizedPlanes.Find(id);
            if(currObj.OverallStatusId < 5)
            {
                currObj.OverallStatusId++;
            }
            _db.CustomizedPlanes.Update(currObj);
            _db.SaveChanges();
            return RedirectToAction("AeroplaneOrders", "Admin");
        }


        public IActionResult OtherOrders()
        {
            //if (HttpContext.Session.GetString("role") != "4")
            //{
            //    return RedirectToAction("OnlyUsers", "Messages");
            //}
            //IEnumerable<CustomizedPlane> objList = _db.CustomizedPlanes
            //        .Include(cp => cp.Plane)
            //        .Include(cp => cp.OverallStatus)
            //        .Include(cp => cp.PlaneDesignScheme)
            //        .Include(cp => cp.FloorPlan)
            //        .Where(cp => cp.IsBasket == false)
            //        .ToList();
            return View();
        }   
    }
}
