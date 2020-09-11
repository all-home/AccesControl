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
       public SearchByTagIDController(ISearchByTagID searchByTagID)
        {
            WorkerByTagID = searchByTagID;        
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int? TagID)
        {
           try
           
            {
                Worker CWorker = WorkerByTagID.GetWorker(TagID);
                if (CWorker != null)
                {
                    return View(CWorker);
                }
                else
                {
                    return View("index"); 
                }
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
