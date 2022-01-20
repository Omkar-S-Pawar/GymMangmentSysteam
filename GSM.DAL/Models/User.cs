using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSM.DAL.Models
{

    public class User : IdentityUser
    {

        [Required]
        [StringLength(25, ErrorMessage = "Name length can't be more than 25.")]
        [Display(Name = "Name", Prompt = "Enter Name")]
        public string Name { get; set; }

        [Display(Name = "Age", Prompt = " Enter Age")]
        [Required(ErrorMessage = "Age is Required")]
        public int Age { get; set; }

        [Display(Name = "Gender", Prompt = " Enter Gender")]
        public int? Gender { get; set; }

        [Display(Name = "Is Active", Prompt = "Is Active ?")]
        public bool? IsActive { get; set; }

        [Display(Name = "Created Date", Prompt = " Enter Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Subcription Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SubcriptionDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdateDate { get; set; }


        [Display(Name = "Subcription")]
        public int PlanId { get; set; }

        [Display(Name = "Trainner", Prompt = "Enter Trainner")]
        public int TrainnerId { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        //One to One
        [ForeignKey("TrainnerId")]
        public virtual Traniner Traniner { get; set; }
        //One to One
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }
        // Many To Many
        public IList<UserWorkoutDay> UserWorkoutDays { get; set; }
    }
}
