using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccesControl.Models;
using Microsoft.AspNetCore.Authorization;

namespace AccesControl.Controllers
{
    public class HomeController : Controller
    {
       //[Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            return View();
        }
                
    }
}
