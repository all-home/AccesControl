using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using WorkersDB.Models;

namespace AccesControl.Controllers
{
    public class SearchByTagIDController : Controller
    {
        ISearchByTagID WorkerByTagID;
        SearchByTagIDController(ISearchByTagID searchByTagID)
        {
            WorkerByTagID = searchByTagID;        
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? TagID)
        {
            try
            {
                Worker CWorker = WorkerByTagID.GetWorker(TagID);
                if (CWorker != null)
                {
                    return View("_index", CWorker);
                }
                else
                {
                    return View(); 
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
