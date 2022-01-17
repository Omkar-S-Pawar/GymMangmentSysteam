using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DAL.Models
{
    public class WorkoutDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        // Many to Many
        public IList<UserWorkoutDay> UserWorkoutDays { get; set; }
    }
}
