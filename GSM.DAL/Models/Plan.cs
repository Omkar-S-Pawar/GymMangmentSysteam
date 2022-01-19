using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSM.DAL.Models
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Subcription")]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [Display(Name = "Created Date", Prompt = "Enter Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }

        // One to Many
        public virtual ICollection<User> Users { get; set; }
    }
}
