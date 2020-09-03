using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    class WorkerModel
    {
        public int id { get; set; }
        public int TagId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Tel { get; set; }
        public string Position { get; set; }
        public IFormFile Image { get; set; }
    }
}
