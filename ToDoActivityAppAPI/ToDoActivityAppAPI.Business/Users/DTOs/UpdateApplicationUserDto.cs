using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoActivityAppAPI.Business.Users.DTOs
{
    public class UpdateApplicationUserDto
    {
        [Required]
        [DefaultValue("")]
        public string Name { get; set; }

        [Required]
        [DefaultValue("")]
        public string Surname { get; set; }

        [DefaultValue("")]
        public string? Location { get; set; }

        [DefaultValue(null)]
        public DateTime? Birthdate { get; set; }

    }
}
