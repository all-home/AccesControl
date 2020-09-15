using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using ProfilesDB.Model;

namespace AccesControl.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfiles profileRepo;

        public ProfileController(IProfiles profile)
        {
            profileRepo = profile;
        }

        // GET: ProfileController
        public ActionResult Index()
        {
            return View(profileRepo.Get());
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View(profileRepo.Get(id));
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profile profile)
        {
            try
            {
                profileRepo.Create(profile);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(profileRepo.Get(id));
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profile profile)
        {
            try
            {
                profileRepo.Update(profile);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(profileRepo.Get(id));
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                profileRepo.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
