using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace RaythosAerospace101.Controllers
{
    public class BaseController : Controller
    {
        //protected override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    // Set the user role in session
        //    HttpContext.Session.SetString("UserRole", "Admin"); // Set the appropriate user role

        //    base.OnActionExecuting(context);
        //}
    }
}
