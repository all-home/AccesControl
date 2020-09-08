using WorkersDB.Models;
using WorkersDB.Interfaces;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WorkersDB
{
    public class WorkersRepository : IGRUDWorker
    {
        private WorkerContext context;

        public WorkersRepository(WorkerContext _context)
        {
            context = _context;
        }

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
            WorkerCurrent.Image = item.Image;
            WorkerCurrent.Tel = item.Tel;
            WorkerCurrent.TagId = item.TagId;

            context.WorkersItems.Update(WorkerCurrent);
            context.SaveChanges();

        }

        public Worker GetWorkerByTagID(int? TagId)
        {
            return context.WorkersItems.
                FirstOrDefault(m => m.TagId == TagId); 
        }
                
    }
}
