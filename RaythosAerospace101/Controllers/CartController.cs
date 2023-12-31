using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaythosAerospace101.Data;
using RaythosAerospace101.Models;
using RaythosAerospace101.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaythosAerospace101.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(IHttpContextAccessor httpContextAccessor, ApplicationDbContext db)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") != "4" && HttpContext.Session.GetString("role") != "3")
                return RedirectToAction("OnlyUsers", "Messages");

            string loggedEmail = HttpContext.Session.GetString("email");

            var ViewModel = new CustomizedPlanes__SparePartOrders
            {
                CustomizedPlanes = _db.CustomizedPlanes
                    .Include(cp => cp.Plane)
                    .Include(cp => cp.FloorPlan)
                    .Include(cp => cp.PlaneDesignScheme)
                    .Where(cp => cp.UserEmail == loggedEmail)
                    .Where(cp => cp.OverallStatusId == 1)
                    .Where(cp => cp.IsBasket == true)
                    .ToList(),
                SparePartOrders = _db.SparePartOrders
                    .Include(cp => cp.SparePart)
                    .Where(cp => cp.UserEmail == loggedEmail)
                    .Where(cp => cp.Status == "InCart")
                    .Where(cp => cp.Qty > 0)
                    .ToList()
            };
            return View(ViewModel);
        }

        public IActionResult DeleteCustomizedPlane()
        {
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSparePart()
        {
            return RedirectToAction("Index");
        }

        public IActionResult PayForAll(string id)
        {
            if (HttpContext.Session.GetString("role") != "4" && HttpContext.Session.GetString("role") != "3")
                return RedirectToAction("OnlyUsers", "Messages");

            string loggedEmail = HttpContext.Session.GetString("email");

            //var ViewModel = new CustomizedPlanes__SparePartOrders
            //{
            //    CustomizedPlanes = _db.CustomizedPlanes
            //        .Include(cp => cp.Plane)
            //        .Include(cp => cp.FloorPlan)
            //        .Include(cp => cp.PlaneDesignScheme)
            //        .Where(cp => cp.UserEmail == loggedEmail)
            //        .Where(cp => cp.OverallStatusId == 1)
            //        .Where(cp => cp.IsBasket == true)
            //        .ToList(),
            //    SparePartOrders = _db.SparePartOrders
            //        .Include(cp => cp.SparePart)
            //        .Where(cp => cp.UserEmail == loggedEmail)
            //        .Where(cp => cp.Status == "InCart")
            //        .Where(cp => cp.Qty > 0)
            //        .ToList()
            //};

            var customizedPlanes = _db.CustomizedPlanes
                    .Include(cp => cp.Plane)
                    .Include(cp => cp.FloorPlan)
                    .Include(cp => cp.PlaneDesignScheme)
                    .Where(cp => cp.UserEmail == loggedEmail)
                    .Where(cp => cp.OverallStatusId == 1)
                    .Where(cp => cp.IsBasket == true)
                    .ToList();

            foreach (var item in customizedPlanes)
            {
                if (item.OverallStatusId == 1 && item.IsBasket == true)
                {
                    item.OverallStatusId = 2;
                    item.IsBasket = false;
                    _db.CustomizedPlanes.Update(item);
                    _db.SaveChanges();
                }
            }

            var sparePartOrders = _db.SparePartOrders
                    .Include(cp => cp.SparePart)
                    .Where(cp => cp.UserEmail == loggedEmail)
                    .Where(cp => cp.Status == "InCart")
                    .Where(cp => cp.Qty > 0)
                    .ToList();

            foreach (var item in sparePartOrders)
            {
                if (item.Status == "InCart")
                {
                    item.Status = "Paid";
                    _db.SparePartOrders.Update(item);
                    _db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
