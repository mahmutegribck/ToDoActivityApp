using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoActivityAppAPI.Business.Images.DTOs
{
    public class GetImageDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public bool IsFavorite { get; set; }
        public string Text { get; set; }
    }
}
