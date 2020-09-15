using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkersDB.Interfaces;
using WorkersDB.Models;
using AccesControl.ViewModels;
using System.Data.SqlTypes;
using BusinessLogic.Interfaces;

namespace AccesControl.Controllers
{
    public class StatController : Controller
    {
        IStat stat;
        IWorkersRepo workersRepo;

        public StatController(IStat _stat, IWorkersRepo _Repo)
        {
            stat = _stat;
            workersRepo = _Repo;
        }
        public IActionResult Index()
        {
            var _stat = stat.Get();
            List<StatModel> statModels = new List<StatModel>();
            try
            {
                foreach (Statistics a in _stat)
                {
                    Worker cWorker = workersRepo.Get(a.WorkerID);

                    statModels.Add(new StatModel
                    {
                        WorkerID = cWorker.id,
                        Name = cWorker.Name,
                        Surname = cWorker.Surname,
                        Patronymic = cWorker.Patronymic,
                        StartWork = a.StartWork,
                        EndWork = a.EndWork,
                        Late = a.Late,
                        Latetime = a.Latetime

                    }); ;
                }
            }
            catch { }

            if (statModels != null)
            {
                return View(statModels);
            }
            else
            {
                return View();
            }
            
        }
    }
}
