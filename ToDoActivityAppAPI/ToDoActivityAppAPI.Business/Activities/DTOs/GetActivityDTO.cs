using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Business.Activities.DTOs
{
    public class GetActivityDTO
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DayNumbers { get; set; }
        public double Budget { get; set; }
        public string Location { get; set; }
        public bool Timed { get; set; }
        public bool Done { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
