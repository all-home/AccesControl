using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            string _patch = null;
            if (file != null)
            {
                var FileName = $"{Guid.NewGuid().ToString()}.jpg";
                var filePath = Path.Combine(_appEnvironment.ContentRootPath + "\\wwwroot\\_files\\", FileName);
                _patch = filePath;

                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }

               FilesDB.Create(new Files
                {
                    Patch = _appEnvironment.ContentRootPath + "/wwwwroot/Files/" + FileName,
                    Name = FileName
                });
            }
            return _patch;
        }

                
    }
}
