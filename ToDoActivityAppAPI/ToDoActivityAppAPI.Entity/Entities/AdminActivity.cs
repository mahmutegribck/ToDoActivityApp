using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Entity.Entities
{
    public class AdminActivity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string? Location { get; set; }
        public string? ImageURL { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
