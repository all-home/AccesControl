﻿using System;
using System.Collections.Generic;
using WorkersDB.Interfaces;
using WorkersDB.Models;
using BusinessLogic.Interfaces;
using System.Linq;
using ProfilesDB.Model;

namespace BusinessLogic.SearchWorkerByTagID
{
    public class GetWorkerByTag : ISearchByTagID
    {
        IStat statRepo;
        IProfiles profileRepo;
        IGRUDWorker workerRepo;
        public GetWorkerByTag(IStat _statRepo, IProfiles _profileRepo, IGRUDWorker _workerRepo)
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

        
        private void addStatResUser(Worker worker)
        {
            var WorkerDayStat = CurentDayEnterice(worker.id);

            if (WorkerDayStat == null)
            {
                Profile cprofile = profileRepo.GetActive();
                DateTime dateTime = DateTime.Now;
                bool Late = LateWorker(dateTime);
                string LateTime = null;
               
                if (Late)
                {
                    LateTime = LateTimeCalc(dateTime);
                }

                statRepo.Create(new Statistics { 
                
                        StartWork = dateTime,
                        Late = Late,
                        Latetime = LateTime,
                        WorkerID = worker.id
                
                });;

            }
            else
            {
                //add owertime !?
                Statistics statistics = WorkerDayStat.FirstOrDefault(a => a.EndWork == null);

                if (statistics != null)
                {
                    statistics.EndWork = DateTime.Now;
                    statRepo.Update(statistics);
                }
                else
                {
                    statRepo.Create(new Statistics
                    {

                        StartWork = DateTime.Now,
                        Late = false,
                        Latetime = null,
                        WorkerID = worker.id

                    }); ;

                }
            
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

        private bool LateWorker(DateTime date)
        {
            Profile profile = profileRepo.GetActive();
            
            if (profile != null)
            {
               
                if (profile.StartWorking.Hour > date.Hour &&
                        profile.StartWorking.Minute > date.Minute)
                {
                    return true;
                }
                else
                {
                    return false;   
                }
            
            }
            else
            {
                return false;
            }
        
        }

        private string LateTimeCalc(DateTime date)
        {
            Profile profile = profileRepo.GetActive();
        
            int hlate = date.Hour - profile.StartWorking.Hour;
            int mlate = date.Minute - profile.StartWorking.Minute;

            return hlate.ToString() + ":" + mlate.ToString();
        
        }
    }
}