using System;
using System.Collections.Generic;
using System.Text;
using FileSave.Models;

namespace FileSave.interfaces
{
    interface IFilesDB
    {
        IEnumerable<File> Get();
        File Get(int id);
        void Create(File file);
        File Delete(int id);
         


    }
}
