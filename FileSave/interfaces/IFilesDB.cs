using System;
using System.Collections.Generic;
using System.Text;
using FileSave.Models;

namespace FileSave.interfaces
{
    public interface IFilesDB
    {
        IEnumerable<Files> Get();
        Files Get(int id);
        void Create(Files file);
        Files Delete(int id);
         


    }
}
