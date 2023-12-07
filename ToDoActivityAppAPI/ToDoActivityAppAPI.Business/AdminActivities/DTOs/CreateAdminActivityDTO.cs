using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoActivityAppAPI.Business.AdminActivities.DTOs
{
    public class CreateAdminActivityDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string? Location { get; set; }
        public string? ImageURL { get; set; }
    }
}
