using System;
using System.ComponentModel.DataAnnotations;

namespace GSM.DAL.Models
{
    public class UserWorkoutDay
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkId { get; set; }
        public bool IsActive { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }

        public User User { get; set; }
        public WorkoutDay WorkoutDay { get; set; }
    }
}
