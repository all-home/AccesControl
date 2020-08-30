using System;
using System.Collections.Generic;
using System.Text;
using FileSave.Models;

namespace FileSave.interfaces
{
    interface FilesDB
    {
        IEnumerable<File> Get();
        void Get(int id);
        void Create(File file);
        void Delete(int id);
         


    }
}
