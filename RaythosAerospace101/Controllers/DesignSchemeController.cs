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
    public class DesignSchemeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DesignSchemeController(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyAdmin", "Messages");
            }
            IEnumerable<PlaneDesignScheme> objList = _db.PlaneDesignSchemes;
            return View(objList);
        }

        public IActionResult New()
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyAdmin", "Messages");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(PlaneDesignScheme obj)
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyAdmin", "Messages");
            }
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
                obj.Stat = "Active";

                _db.PlaneDesignSchemes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "DesignScheme");

            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyAdmin", "Messages");
            }
            var designScheme = _db.PlaneDesignSchemes.Find(id);
            if (designScheme == null)
            {
                return RedirectToAction("NotFound", "Messages");
            }
            return View(designScheme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PlaneDesignScheme obj)
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyAdmin", "Messages");
            }
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
                    obj.Image_Path = uniqueFileName;

                    //string img_path = "/wwwroot/images/planes/" + uniqueFileName;

                }

                // Store the file path in a variable (img_path)

                #endregion

                obj.isActive = true;
                obj.Stat = "Active";

                _db.PlaneDesignSchemes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "DesignScheme");

            }

            return View();
        }

        public IActionResult Hide(int id)
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyAdmin", "Messages");
            }

            var designScheme = _db.PlaneDesignSchemes.Find(id);
            if (designScheme == null)
            {
                return RedirectToAction("NotFound", "Messages");
            }

            if (designScheme.Stat == "Active")
            {
                designScheme.Stat = "Hidden";
            }
            else if (designScheme.Stat == "Hidden")
            {
                designScheme.Stat = "Active";
            }
            else
            {
                return RedirectToAction("UnexpectedError", "Messages");
            }

            _db.PlaneDesignSchemes.Update(designScheme);
            _db.SaveChanges();
            return RedirectToAction("Index", "DesignScheme");
        }
        
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("role") != "4")
            {
                return RedirectToAction("OnlyAdmin", "Messages");
            }

            var designScheme = _db.PlaneDesignSchemes.Find(id);
            if (designScheme == null)
            {
                return RedirectToAction("NotFound", "Messages");
            }

            if (designScheme.Stat == "Active" || designScheme.Stat == "Hidden")
            {
                designScheme.Stat = "Deleted";
            }
            else
            {
                return RedirectToAction("UnexpectedError", "Messages");
            }

            _db.PlaneDesignSchemes.Update(designScheme);
            _db.SaveChanges();
            return RedirectToAction("Index", "DesignScheme");
        }
    }
}
