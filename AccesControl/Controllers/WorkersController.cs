using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using WorkersDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace AccesControl.Controllers
{
    
    public class WorkersController : Controller
    {
        private readonly IWorkersRepo repo;

        public WorkersController(IWorkersRepo repo)
        {
            this.repo = repo;
        }


        // GET: WorkersController
        
        public ActionResult Index()
        {
            return View(repo.Get());
        }

        // GET: WorkersController/Details/5
        public ActionResult Details(int id)
        {
            Worker worker = repo.Get(id);
            return View(worker);
        }

        // GET: WorkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name, Surname, Patronymic, Tel, Position,TagId,Image")] WorkerModel worker)
        {
           
            try
            {
                repo.Create(worker);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Create));
            }
        }

        // GET: WorkersController/Edit/5
        public ActionResult Edit(int id)
        {
            Worker worker = repo.Get(id);
            return View(worker);
        }

        // POST: WorkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("id, Name, Surname, Patronymic, Tel, Position,TagId,Image")] WorkerModel worker)
        {
            try
            {
                repo.Update(worker);
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
                repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
