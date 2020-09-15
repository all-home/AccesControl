using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorkersDB.Interfaces;
using WorkersDB.Models;
using FileSave.interfaces;
using BusinessLogic.Interfaces;
using System.Linq;

namespace BusinessLogic.WorkersRepo
{
    public class Workers : IWorkersRepo
    {
        private readonly IGRUDWorker WorkRepo;
        private readonly IFileUGD File;
        private readonly IStat statRepo;

        public Workers(IGRUDWorker gRUDWork, IFileUGD _File, IStat stat)
        {
            File = _File;
            WorkRepo = gRUDWork;
            statRepo = stat;
        }

        public IEnumerable<Worker> Get()
        {
            return WorkRepo.Get();
        }

        public Worker Get(int id)
        {
            return WorkRepo.Get(id);
        }

        public void Create(WorkerModel item)
        {
            if (item != null && TagIdChec(item.TagId))
            {
                Worker NewWorker = new Worker
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    Patronymic = item.Patronymic,
                    Tel = item.Tel,
                    TagId = item.TagId ?? default(int),
                    Position = item.Position,
                    Image = File.Upload(item.Image)

                };
                WorkRepo.Create(NewWorker);
            }
        }

        public void Delete(int id)
        {
            statRepo.Delete(GetWorkerStat(id));
            WorkRepo.Delete(id);
            
        }

        public void Update(WorkerModel item)
        {
            Worker WorkerCurrent = Get(item.id);

            if (WorkerCurrent != null && TagIdChec(item.TagId))
            {
                WorkerCurrent.Name = item.Name;
                WorkerCurrent.Surname = item.Surname;
                WorkerCurrent.Patronymic = item.Patronymic;
                WorkerCurrent.Position = item.Position;
                WorkerCurrent.Image = File.Upload(item.Image);
                WorkerCurrent.Tel = item.Tel;
                WorkerCurrent.TagId = item.TagId ?? default(int);

                WorkRepo.Update(WorkerCurrent);
            }                      

        }

        //get worker stat by him id
        public IEnumerable<Statistics> GetWorkerStat(int id)
        {
            var stat = statRepo.Get();
            Worker cWorker = Get(id);
            var cWorkerStat = stat.Where(a => a.WorkerID == cWorker.id);
            return cWorkerStat;
                      
        }


        //Check Readed Tag
        private bool TagIdChec (int? TagId)
        {
            if (TagId != null)
            {
                Worker Workers = WorkRepo.GetWorkerByTagID(TagId);
                if (Workers == null)
                {
                    return true;
                }

            }
            else
            {
                return false;
            }
            return false; 
            
        }

    }
}
