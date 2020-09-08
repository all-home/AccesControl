using System;
using System.Collections.Generic;
using System.Text;
using WorkersDB.Interfaces;
using ProfilesDB.Interfaces;
using WorkersDB.Models;
using BusinessLogic.Interfaces;
using System.Linq;

namespace BusinessLogic.SearchWorkerByTagID
{
    public class GetWorkerByTag : ISearchByTagID
    {
        IStat statRepo;
        IProfileRepo profileRepo;
        IGRUDWorker workerRepo;
        public GetWorkerByTag(IStat _statRepo, IProfileRepo _profileRepo, IGRUDWorker _workerRepo)
        {
            statRepo = _statRepo;
            profileRepo = _profileRepo;
            workerRepo = _workerRepo;
        }

        public Worker GetWorker(int? TagID)
        {
            Worker ResWoker = null;

            if (TagID != null)
            {
                 ResWoker = workerRepo.GetWorkerByTagID(TagID);
            }
            addStatResUser(ResWoker);
            return ResWoker;
        }

        //add user stat
        /*
         add stat user
        add laate check
         */
        private void addStatResUser(Worker worker)
        {
            var WorkerDayStat = CurentDayEnterice(worker.id);

            if (WorkerDayStat == null)
            {
                statRepo.Create(new Statistics { 
                
                
                
                });

            }
            else
            { 
            
            }
        
        }

        private IEnumerable<Statistics> CurentDayEnterice(int id)
        {
            var Stat = statRepo.Get();

            var dayStat = Stat.Where(a =>
                a.StartWork.Date.ToString("dd.MM.yyy") == DateTime.Now.ToString("dd.MM.yyy") && a.WorkerID == id);

            if (dayStat != null)
            {
                return dayStat;
            }
            else
            {
                return null;
            }
        }
    }
}
