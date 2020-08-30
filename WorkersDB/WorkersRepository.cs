using System;
using WorkersDB.Models;
using WorkersDB.Interfaces;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace WorkersDB
{
    public class WorkersRepository : IGRUDWork
    {
        private WorkerContext context;
        public IEnumerable<Worker> Get()
        {
            return context.WorkersItems;
        }
        public Worker Get(int id)
        {
            return context.WorkersItems.Find(id);
        }

        public void Create(Worker item)
        {
            context.WorkersItems.Add(item);
            context.SaveChanges();
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

            context.WorkersItems.AddOrUpdate(WorkerCurrent);
            context.SaveChanges();

        }
    }
}
