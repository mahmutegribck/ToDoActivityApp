using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Entities;

namespace ToDoActivityAppAPI.Entity.Identity
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Location { get; set; }

        public DateTime? Birthdate { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }


        public ICollection<Activity> Activities { get; set; }

    }
}
