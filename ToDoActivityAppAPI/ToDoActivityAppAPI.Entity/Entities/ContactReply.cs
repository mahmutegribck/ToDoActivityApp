﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Entity.Entities
{
    public class ContactReply
    {
        [Key]
        public int ContactReplyId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }


        //public Contact Contact { get; set; }
        //public int ContactId { get; set; }

       
    }
}
