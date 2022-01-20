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
        [Display(Name ="Name" ,Prompt = "Enter Name")]
        public string Name { get; set; }
        [Display(Name = "Email", Prompt = " Enter Email Id")]
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Display(Name = "Password", Prompt = " Enter Password")]
        public string Password { get; set; }
        [Display(Name = "Phone", Prompt = " Enter Phone")]
        [Required(ErrorMessage = "Phone number is Required")]
        [RegularExpression(@"^([0]|\+91[\-\s]?)?[789]\d{9}$", ErrorMessage = "Entered Mobile No is not valid.")]
        public string Phone { get; set; }
        [Display(Name = "Age", Prompt = " Enter Age")]
        //[RegularExpression("^(^[1-99]{2}$)$", ErrorMessage = "Age must bebetween 1 and 100")]
        public int Age { get; set; }

        [Display(Name = "Gender", Prompt = " Enter Gender")]
        public int? Gender { get; set; } = 0;
        public int? Role { get; set; }
        [Display(Name = "Is Active", Prompt = "Is Active ?")]
        public bool? IsActive { get; set; }
        [Display(Name = "Created Date", Prompt = "Enter Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }      
        public string UpdatedBy { get; set; }
        [Display(Name = "Subcription")]
        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }

        [Display(Name = "Trainner", Prompt = "Enter Trainner")]
        public int TrainnerId { get; set; }
     
        [ForeignKey("TrainnerId")]
        public virtual Traniner Traniner { get; set; }

        // Many To Many
        public IList<UserWorkoutDay> UserWorkoutDays { get; set; }
    }
}
