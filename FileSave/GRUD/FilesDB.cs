using System;
using System.Collections.Generic;
using System.Text;
using FileSave.interfaces;
using FileSave.Models;

namespace FileSave.GRUD
{
    class FilesDB : IFilesDB
    {
        FileContext Context;
        public void Create(File file)
        {
            Context.FileItems.Add(file);
            Context.SaveChanges();
        }

        public File Delete(int id)
        {
            File file = Get(id);

            if (file != null)
            {
                Context.FileItems.Remove(file);
                Context.SaveChanges();
            
            }

            return file;
        }

        public IEnumerable<File> Get()
        {
            return Context.FileItems;
        }

        public File Get(int id)
        {
            return Context.FileItems.Find(id);
        }
    }
}
