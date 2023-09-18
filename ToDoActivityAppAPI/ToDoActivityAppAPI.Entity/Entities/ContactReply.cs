using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoActivityAppAPI.Entity.Entities
{
    public class ContactReply
    {
        [Key]
        public int ContactReplyId { get; set; }

        public string ContactReplyText { get; set; }

        public DateTime ContactReplyDate { get; set; }

        public Contact Contact { get; set; }

        public int ContactId { get; set; }
    }
}
