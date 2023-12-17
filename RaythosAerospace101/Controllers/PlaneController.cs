﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class PlaneController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public FloorPlanDesignScheme ViewModel { get; private set; }

        public PlaneController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview(int id)
        {
            var plane = _db.Planes.Find(id);
            if (plane == null)
            {
                return NotFound();
            }
            string[] data = { HttpContext.Session.GetString("role") };
            //ViewBag.data = data;
            return View(plane);
        }

        // GET: CustomizeNew
        public IActionResult CustomizeNew()
        {
             ViewModel = new FloorPlanDesignScheme
            {
                FloorPlans = _db.FloorPlans.ToList(),
                planeDesignSchemes = _db.PlaneDesignSchemes.ToList()
            };
            return View();
        }

        // GET: Add
        public IActionResult Add()
        {
            string[] data = { HttpContext.Session.GetString("role") };
            return View(data);
        }

        // POST: Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Plane obj)
        {
            ViewBag.Message = "checked";

            if (ModelState.IsValid)
            {
                #region // Input Validation
                if (obj.Name == "")
                    ModelState.AddModelError("addPlane", "Title can't be empty");
                else if (obj.Heading1 == "")
                    ModelState.AddModelError("addPlane", "Heading 1 can't be empty");
                else if (obj.Para1 == "")
                    ModelState.AddModelError("addPlane", "Paragraph 1 can't be empty");
                else if (obj.Distant.ToString() == "")
                    ModelState.AddModelError("addPlane", "Distant can't be empty");
                else if (obj.Distant < 0)
                    ModelState.AddModelError("addPlane", "Distant should be more than 0");
                else if (obj.Mach.ToString() == "")
                    ModelState.AddModelError("addPlane", "Mach Number can't be empty");
                else if (obj.Mach < 0)
                    ModelState.AddModelError("addPlane", "Mach Number should be more than 0");
                else if (obj.Baggage.ToString() == "")
                    ModelState.AddModelError("addPlane", "Storage size can't be empty");
                else if (obj.Baggage < 0)
                    ModelState.AddModelError("addPlane", "Storage size should be more than 0");
                else if (obj.Heading2 == "")
                    ModelState.AddModelError("addPlane", "Heading 2 can't be empty");
                else if (obj.Para2 == "")
                    ModelState.AddModelError("addPlane", "Paragraph 2 can't be empty");
                else if (obj.Price.ToString() == "")
                    ModelState.AddModelError("addPlane", "Price can't be empty");
                else if (obj.Price < 0)
                    ModelState.AddModelError("addPlane", "Price should be more than 0");
                #endregion

                string uniqueFileName = "";

                #region  // Save the Image to "Images/Planes and saves the Url in "img_path"

                var file = Request.Form.Files["input_productImg"];
                if (file != null && file.Length > 0)
                {
                    // Define the folder where you want to save the images
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images", "planes");

                    // Ensure the folder exists, create if not
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Generate a unique filename for the uploaded file
                     uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                    // Combine the folder path and the unique filename
                    var filePath = Path.Combine(uploadFolder, uniqueFileName);

                    // Save the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    string img_path = "/wwwroot/images/planes/" + uniqueFileName;

                }

                // Store the file path in a variable (img_path)

                #endregion

                obj.Image = uniqueFileName;
                obj.isActive = true;

                _db.Planes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Planes", "Admin");

            }

            return View();
        }


    }
}
