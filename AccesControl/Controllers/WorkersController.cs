using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkersDB;
using WorkersDB.Interfaces;
//using BusniessLogic;

namespace AccesControl.Controllers
{
    public class WorkersController : Controller
    {
          
        // GET: WorkersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorkersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
