using System;
using System.IO;
using System.Linq;
using FileSave.interfaces;
using FileSave.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace FileSave
{
    public class FiileDelGetUpload : IFileUGD
    {
        IFilesDB FilesDB;
        IHostingEnvironment _appEnvironment;
        public FiileDelGetUpload(IHostingEnvironment appEnvironment, IFilesDB _FilesDB)
        {
            FilesDB = _FilesDB;
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

        public string Upload(IFormFile file)
        {
           string FileName = GetFilename();
           string patch = _appEnvironment.ContentRootPath + "/Files/" + FileName;
                        
           using (var fileStream = new FileStream(patch, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }

            FilesDB.Create(new Files { 
            Patch = patch,
            Name = FileName
            });
            return patch;
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
