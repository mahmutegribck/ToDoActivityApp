using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoActivityAppAPI.Business.Contacts.DTOs
{
    public class CreateContactDTO
    {

        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }      
        

    }
}
