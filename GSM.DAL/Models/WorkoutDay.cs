using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GSM.DAL.Models
{
    public class WorkoutDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        // Many to Many
        public IList<UserWorkoutDay> UserWorkoutDays { get; set; }
    }
}
