using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Entity.Entities
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        [DefaultValue(false)]
        public bool Check { get; set; }

        public ContactReply ContactReply { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
