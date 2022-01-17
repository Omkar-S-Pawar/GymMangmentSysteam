using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSM.DAL.Models
{

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Name length can't be more than 25.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone number is Required")]
        [RegularExpression(@"^([0]|\+91[\-\s]?)?[789]\d{9}$", ErrorMessage = "Entered Mobile No is not valid.")]
        public string Phone { get; set; }
        public int Age { get; set; }
        public int? Gender { get; set; }
        public int? Role { get; set; }
        public bool? IsActive { get; set; }
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dddd, d MMMM , yyyy}")]
        public DateTime? CreatedDate { get; set; }        
        public DateTime? UpdateDate { get; set; }       
        public string CreatedBy { get; set; }      
        public string UpdatedBy { get; set; }
        
        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }

        [Display(Name = "Trainner")]
        public int TrainnerId { get; set; }
     
        [ForeignKey("TrainnerId")]
        public virtual Traniner Traniner { get; set; }


        // Many To Many
        public IList<UserWorkoutDay> UserWorkoutDays { get; set; }
    }
}
