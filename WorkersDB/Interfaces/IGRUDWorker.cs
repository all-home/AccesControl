using System.Collections.Generic;
using WorkersDB.Models;

namespace WorkersDB.Interfaces
{
    public interface IGRUDWorker
    {
        IEnumerable<Worker> Get();
        Worker Get(int id);
        void Create(Worker item);
        void Update(Worker item);
        Worker Delete(int id);
        Worker GetWorkerByTagID(int? TagID);
        
    }
}
