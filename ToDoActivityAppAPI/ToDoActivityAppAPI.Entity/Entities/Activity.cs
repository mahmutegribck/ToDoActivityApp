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
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? DayNumbers { get; set; } 
        public double? Budget { get; set; }
        public string? Location { get; set; }

        [DefaultValue(false)]
        public bool Timed { get; set; }

        [DefaultValue(false)]
        public bool Done { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
