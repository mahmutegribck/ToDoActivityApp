using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoActivityAppAPI.Entity.Identity
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Location { get; set; }
    }
}
