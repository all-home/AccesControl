using System;
using System.Collections.Generic;
using System.Text;
using FileSave.interfaces;
using FileSave.Models;

namespace FileSave.GRUD
{
    public class FilesDB : IFilesDB
    {
        private readonly FileContext Context;
        public void Create(Files file)
        {
            Context.FileItems.Add(file);
            Context.SaveChanges();
        }

        public Files Delete(int id)
        {
            Files file = Get(id);

            if (file != null)
            {
                Context.FileItems.Remove(file);
                Context.SaveChanges();
            
            }

            return file;
        }

        public IEnumerable<Files> Get()
        {
            return Context.FileItems;
        }

        public Files Get(int id)
        {
            return Context.FileItems.Find(id);
        }
    }
}
