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
    public class SparePartsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _db;

        public SparePartsController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("role") != "4")
            //    return RedirectToAction("OnlyAdmin", "Messages");
            IEnumerable<SparePart> objList = _db.SpareParts;
            return View(objList);
        }

        public IActionResult New()
        {
            if (HttpContext.Session.GetString("role") != "4")
                return RedirectToAction("OnlyAdmin", "Messages");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(SparePart obj)
        {
            if (HttpContext.Session.GetString("role") != "4")
                return RedirectToAction("OnlyAdmin", "Messages");

            var file = Request.Form.Files["img_sparePart"];

            #region // Input Validation
            if (obj.Brand == null || obj.Brand == "")
                ModelState.AddModelError("addSparePart", "Brand Field Can't be empty");
            if (obj.Title == null || obj.Title == "")
                ModelState.AddModelError("addSparePart", "Title Field Can't be empty");
            if (obj.Description == null || obj.Description == "")
                ModelState.AddModelError("addSparePart", "Description Can't be empty");
            if (obj.ManufacturedCountry == null || obj.ManufacturedCountry == "")
                ModelState.AddModelError("addSparePart", "Country Field Can't be empty");
            if (obj.Price == 0 || obj.Price == 0.0)
                ModelState.AddModelError("addSparePart", "Price Field Can't be empty");
            if (obj.Price < 0)
                ModelState.AddModelError("addSparePart", "Price must be a positive number");
            if (file == null)
                ModelState.AddModelError("addSparePart", "Image Field Can't be empty");

            #endregion


            if (ModelState.IsValid)
            {
                // Define the folder where you want to save the images
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "spareParts");

                // Ensure the folder exists, create if not
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // Generate a unique filename for the uploaded file
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // Combine the folder path and the unique filename
                var filePath = Path.Combine(uploadFolder, uniqueFileName);

                // Save the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                obj.ImagePath = uniqueFileName;
                obj.Stat = "Active";
                obj.Qty = 0;

                _db.SpareParts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("role") != "4")
                return RedirectToAction("OnlyAdmin", "Messages");

            var sparePart = _db.SpareParts.Find(id);
            if (sparePart == null)
                return RedirectToAction("NotFound", "Messages");

            return View(sparePart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SparePart obj)
        {
            if (HttpContext.Session.GetString("role") != "4")
                return RedirectToAction("OnlyAdmin", "Messages");

            var file = Request.Form.Files["img_sparePart"];

            #region // Input Validation
            if (obj.Brand == null || obj.Brand == "")
                ModelState.AddModelError("addSparePart", "Brand Field Can't be empty");
            if (obj.Title == null || obj.Title == "")
                ModelState.AddModelError("addSparePart", "Title Field Can't be empty");
            if (obj.Description == null || obj.Description == "")
                ModelState.AddModelError("addSparePart", "Description Can't be empty");
            if (obj.ManufacturedCountry == null || obj.ManufacturedCountry == "")
                ModelState.AddModelError("addSparePart", "Country Field Can't be empty");
            if (obj.Price == 0 || obj.Price == 0.0)
                ModelState.AddModelError("addSparePart", "Price Field Can't be empty");
            if (obj.Price < 0)
                ModelState.AddModelError("addSparePart", "Price must be a positive number");
            

            #endregion

            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "spareParts");

                    // Ensure the folder exists, create if not
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Generate a unique filename for the uploaded file
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                    // Combine the folder path and the unique filename
                    var filePath = Path.Combine(uploadFolder, uniqueFileName);

                    // Save the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.ImagePath = uniqueFileName;
                }
                _db.SpareParts.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public IActionResult UpdateQty(int id, int qty)
        {
            if (HttpContext.Session.GetString("role") != "4")
                return RedirectToAction("OnlyAdmin", "Messages");

            var sparePart = _db.SpareParts.Find(id);

            if (sparePart == null)
                return RedirectToAction("NotFound", "Messages");
            if (sparePart.Stat == "Deleted")
                return RedirectToAction("AlreadyDeleted", "Messages");

            sparePart.Qty = qty;
            _db.SpareParts.Update(sparePart);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Hide(int id)
        {
            if (HttpContext.Session.GetString("role") != "4")
                return RedirectToAction("OnlyAdmin", "Messages");

            var sparePart = _db.SpareParts.Find(id);

            if (sparePart == null)
                return RedirectToAction("NotFound", "Messages");

            if (sparePart.Stat == "Active")
                sparePart.Stat = "Hidden";
            else if (sparePart.Stat == "Hidden")
                sparePart.Stat = "Active";
            else if (sparePart.Stat == "Deleted")
                return RedirectToAction("AlreadyDeleted", "Messages");

            _db.SpareParts.Update(sparePart);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("role") != "4")
                return RedirectToAction("OnlyAdmin", "Messages");

            var sparePart = _db.SpareParts.Find(id);

            if (sparePart == null)
                return RedirectToAction("NotFound", "Messages");

            if (sparePart.Stat == "Active" || sparePart.Stat == "Hidden")
                sparePart.Stat = "Deleted";
            else if (sparePart.Stat == "Deleted")
                return RedirectToAction("AlreadyDeleted", "Messages");

            _db.SpareParts.Update(sparePart);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Overview(int id, bool isError)
        {
            var sparePart = _db.SpareParts.Find(id);

            if (sparePart == null || sparePart.Stat != "Active")
                return RedirectToAction("NotFound", "Messages");

            if(isError)
                ViewBag.ErrorMsg = "Please check the Quantity";
            return View(sparePart);
        }

        public IActionResult AddToCart(int id, int qty)
        {
            if (HttpContext.Session.GetString("role") != "4" && HttpContext.Session.GetString("role") != "3")
                return RedirectToAction("OnlyUsers", "Messages");

            var sparePart = _db.SpareParts.Find(id);

            if (sparePart == null || sparePart.Stat != "Active")
                return RedirectToAction("NotFound", "Messages");

            if (qty < 1 || qty > sparePart.Qty)
                ModelState.AddModelError("errorAddToCart", "Please check the Quantity");

            if (!ModelState.IsValid)
                return RedirectToAction("Overview", new { id = id , isError = true});

            var newOrder = new SparePartOrder
            {
                CurrentDateTime = DateTime.Now,
                Qty = qty,
                Status = "InCart",
                SparePartId = id,
                UserEmail = HttpContext.Session.GetString("email")
            };

            _db.SparePartOrders.Add(newOrder);
            _db.SaveChanges();

            return RedirectToAction("AddedToCart", "Messages", new { Id = id });
        }

        public IActionResult BuyNow(int id, int qty)
        {
            if (HttpContext.Session.GetString("role") != "4" && HttpContext.Session.GetString("role") != "3")
                return RedirectToAction("OnlyUsers", "Messages");

            var sparePart = _db.SpareParts.Find(id);

            if (sparePart == null || sparePart.Stat != "Active")
                return RedirectToAction("NotFound", "Messages");

            if (qty < 1 || qty > sparePart.Qty)
                ModelState.AddModelError("errorAddToCart", "Please check the Quantity");

            if (!ModelState.IsValid)
                return RedirectToAction("Overview", new { id = id, isError = true });

            var newOrder = new SparePartOrder
            {
                CurrentDateTime = DateTime.Now,
                Qty = qty,
                Status = "InCart",
                SparePartId = id,
                UserEmail = HttpContext.Session.GetString("email")
            };

            _db.SparePartOrders.Add(newOrder);
            _db.SaveChanges();

            return RedirectToAction("Cart", "Home");

        }
    }
}
