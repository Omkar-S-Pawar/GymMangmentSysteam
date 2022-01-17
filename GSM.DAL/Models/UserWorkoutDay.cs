using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DAL.Models
{
    public class UserWorkoutDay
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }

        public User User { get; set; }
        public WorkoutDay WorkoutDay { get; set; }
    }
}
