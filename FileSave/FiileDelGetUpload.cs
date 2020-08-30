using System;
using System.IO;
using System.Linq;
using FileSave.GRUD;
using FileSave.interfaces;
using FileSave.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FileSave
{
    public class FiileDelGetUpload : IFileUGD
    {
        FilesDB FilesDB;
        IHostingEnvironment _appEnvironment;
        public FiileDelGetUpload(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public void Delete(int id)
        {
            Files CFile = FilesDB.Get(id);
            File.Delete(CFile.Patch);
            FilesDB.Delete(CFile.id);
        }

        public string GetFileAdress(int id)
        {
            Files CFile = FilesDB.Get(id);

            if (CFile != null)
            {
                return CFile.Patch;
            }
            return null;
        }

        public int? Upload(IFormFile file)
        {
           string FileName = GetFilename();
           int? id = null;
           string patch = _appEnvironment.ContentRootPath + "/Files/" + FileName;

            try
            {
                using (var fileStream = new FileStream(patch, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }
            }
            catch
            {             
            
            }

            return id;
        }

        private string GetFilename()
        {
            string FileName = null;
            do
            {
                FileName = String.Format("%s.%s", RandomStringUtils.RandomStringUtils.RandomAlphanumeric(8));

            }
            while (CheckName(FileName));

            // Check Name
            bool CheckName(string _FileName)
            {
                var Files = FilesDB.Get(); 
                var FName = Files.
                    FirstOrDefault(f => f.Name == _FileName);
                if (FName == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return FileName;
        }
    }
}
