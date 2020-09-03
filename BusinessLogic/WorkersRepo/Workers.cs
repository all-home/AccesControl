using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorkersDB.Interfaces;
using WorkersDB.Models;

namespace BusinessLogic.WorkersRepo
{
    class Workers
    {
        private readonly IGRUDWork WorkRepo;

        public Workers(IGRUDWork gRUDWork)
        {
            WorkRepo = gRUDWork;
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
            Worker NewWorker = new Worker {
                Name = item.Name,
                Surname = item.Surname,
                Patronymic = item.Patronymic,
                Tel = item.Tel,
                TagId = item.TagId,
            
            };
        }

        public Worker Delete(int id)
        {
            Worker Worker = Get(id);

            if (Worker != null)
            {
                context.WorkersItems.Remove(Worker);
                context.SaveChanges();
            }
            return Worker;
        }

        public void Update(Worker item)
        {
            Worker WorkerCurrent = Get(item.id);

            WorkerCurrent.Name = item.Name;
            WorkerCurrent.Surname = item.Surname;
            WorkerCurrent.Patronymic = item.Patronymic;
            WorkerCurrent.Position = item.Position;
            WorkerCurrent.ImageID = item.ImageID;
            WorkerCurrent.Tel = item.Tel;
            WorkerCurrent.TagId = item.TagId;

            context.WorkersItems.Update(WorkerCurrent);
            context.SaveChanges();

        }

        private bool TagIdChec (int TagId)
        {
            return false;
        }

    }
}
