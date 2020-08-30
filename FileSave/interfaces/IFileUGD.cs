﻿using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace FileSave.interfaces
{
    interface IFileUGD
    {
        int? Upload(IFormFile file);
        void Delete(int id);
        string GetFileAdress(int id);
    }
}