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
        public string? Text { get; set; }
        public DateOnly? CreateTime { get; set; }
        public DateOnly? UpdateTime { get; set; }
        public DateOnly? StartTime { get; set; }
        public DateOnly? EndTime { get; set; }
        public int? DayNumbers { get; set; }
        public double? Budget { get; set; }
        public string? Location { get; set; }
        public bool Timed { get; set; }
        public bool Done { get; set; }
    }
}
