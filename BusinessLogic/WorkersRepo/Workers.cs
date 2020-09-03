﻿using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorkersDB.Interfaces;
using WorkersDB.Models;
using FileSave.interfaces;

namespace BusinessLogic.WorkersRepo
{
    class Workers
    {
        private readonly IGRUDWorker WorkRepo;
        private readonly IFileUGD File;

        public Workers(IGRUDWorker gRUDWork, IFileUGD _File)
        {
            File = _File;
            WorkRepo = gRUDWork;
        }

        public IEnumerable<Worker> Get()
        {
            return WorkRepo.Get();
        }

        public Worker Get(int id)
        {
            return WorkRepo.Get(id);
        }

        public void Create(WorkerModel item)
        {
            if (item != null && TagIdChec(item.TagId))
            {
                Worker NewWorker = new Worker
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    Patronymic = item.Patronymic,
                    Tel = item.Tel,
                    TagId = item.TagId ?? default(int),
                    Position = item.Position,
                    ImageID = File.Upload(item.Image) ?? default(int)

                };
                WorkRepo.Create(NewWorker);
            }
        }

        public void Delete(int id)
        {
            WorkRepo.Delete(id);
        }

        public void Update(WorkerModel item)
        {
            Worker WorkerCurrent = Get(item.id);

            if (WorkerCurrent != null && TagIdChec(item.TagId))
            {
                WorkerCurrent.Name = item.Name;
                WorkerCurrent.Surname = item.Surname;
                WorkerCurrent.Patronymic = item.Patronymic;
                WorkerCurrent.Position = item.Position;
                WorkerCurrent.ImageID = File.Upload(item.Image) ?? default(int);
                WorkerCurrent.Tel = item.Tel;
                WorkerCurrent.TagId = item.TagId ?? default(int);

                WorkRepo.Update(WorkerCurrent);
            }                      

        }

        //Check Readed Tag
        private bool TagIdChec (int? TagId)
        {
            if (TagId != null)
            {
                var Workers = WorkRepo.GetWorkerByTagID(TagId);
                if (Workers == null)
                {
                    return true;
                }

            }
            else
            {
                return false;
            }
            return false; 
            
        }

    }
}
