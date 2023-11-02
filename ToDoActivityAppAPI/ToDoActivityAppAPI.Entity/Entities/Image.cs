using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Entity.Entities
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] ImageData { get; set; }

        [DefaultValue(false)]
        public bool IsFavorite { get; set; }    
        public string? Text { get; set; }

        public Activity Activity { get; set; }
        public int ActivityId { get; set; }

    }
}
