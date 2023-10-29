using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Business.Activities.DTOs
{
    public class UpdateActivityDTO
    {
        [DefaultValue("")]
        public string Title { get; set; }

        [DefaultValue("")]
        public string? Text { get; set; }
        
        [DefaultValue(null)]
        public DateTime? StartTime { get; set; }

        [DefaultValue(null)]
        public DateTime? EndTime { get; set; }

        [DefaultValue("")]
        public double? Budget { get; set; }

        [DefaultValue("")]
        public string? Location { get; set; }

        [DefaultValue(false)]
        public bool Timed { get; set; }

        [DefaultValue(false)]
        public bool Done { get; set; }
    }
}
