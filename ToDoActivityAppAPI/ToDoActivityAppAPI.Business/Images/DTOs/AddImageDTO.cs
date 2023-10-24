using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoActivityAppAPI.Business.Images.DTOs
{
    public class AddImageDTO
    {
        public int ActivityId { get; set; }
        public List<IFormFile> Images { get; set; }
        public bool IsFavorite { get; set; }
        public string Text { get; set; }
    }
}
