using System.Collections.Generic;
using WorkersDB.Models;

namespace WorkersDB.Interfaces
{
    public interface IGRUDWork
    {
        IEnumerable<Worker> Get();
        Worker Get(int id);
        void Create(Worker item);
        void Update(Worker item);
        Worker Delete(int id);
        
    }
}
