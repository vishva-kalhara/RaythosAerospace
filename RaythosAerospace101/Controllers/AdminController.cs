using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaythosAerospace101.Data;
using RaythosAerospace101.Models;
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
        
        public IActionResult ManageOrders()
        {
            return View();
        }

        public IActionResult FloorPlans()
        {
            IEnumerable<FloorPlan> objList = _db.FloorPlans;
            return View(objList);
        }

        
        public IActionResult DesignSchemes()
        {
            return View();
        }

        public IActionResult SpareParts()
        {
            return View();
        }

        public IActionResult UserList()
        {
            IEnumerable<User> objList = _db.Users;
            return View(objList);
        }
        
        public IActionResult NewDesignScheme()
        {
            return View();
        }

        //POST: New Flor Plan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewDesignScheme(PlaneDesignScheme obj)
        {
            ViewBag.Message = "checked";

            if (ModelState.IsValid)
            {
                #region // Input Validation
                if (obj.Title == "")
                    ModelState.AddModelError("addPlane", "Title can't be empty");
                else if (obj.Description == "")
                    ModelState.AddModelError("addPlane", "Description can't be empty");
                else if (obj.Price.ToString() == "")
                    ModelState.AddModelError("addPlane", "Price can't be empty");
                else if (obj.Price < 0)
                    ModelState.AddModelError("addPlane", "Price should be more than 0");

                #endregion

                string uniqueFileName = "";

                #region  // Save the Image to "Images/Planes and saves the Url in "img_path"

                var file = Request.Form.Files["img_deigSceheme"];
                if (file != null && file.Length > 0)
                {
                    // Define the folder where you want to save the images
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "design_schemes");

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

                    //string img_path = "/wwwroot/images/planes/" + uniqueFileName;

                }

                // Store the file path in a variable (img_path)

                #endregion

                obj.Image_Path = uniqueFileName;
                obj.isActive = true;

                _db.PlaneDesignSchemes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Planes", "Admin");

            }

            return View();
        }
    }
}
