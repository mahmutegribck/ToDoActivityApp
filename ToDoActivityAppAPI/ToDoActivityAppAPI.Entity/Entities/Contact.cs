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
        public string ContactEmailAddress { get; set; }

        public string ContactText { get; set; }

        public DateTime ContactDate { get; set; }

        [DefaultValue(false)]
        public bool ContactCheck { get; set; }

        public ContactReply ContactReply { get; set; }


        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
