using System.ComponentModel.DataAnnotations.Schema;

namespace FileSave.Models
{
    public class Files
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public string Patch { get; set; }
    }
}

