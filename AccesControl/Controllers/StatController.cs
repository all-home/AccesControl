using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkersDB.Interfaces;
using WorkersDB.Models;

namespace AccesControl.Controllers
{
    public class StatController : Controller
    {
        IStat stat;

        public StatController(IStat _stat)
        {
            stat = _stat;        
        }
        public IActionResult Index()
        {
            
            return View(stat.Get());
        }
    }
}
