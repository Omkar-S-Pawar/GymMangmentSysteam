using GSM.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GSM.Service.ViewModel
{
    public class vwUserInfo
    {
        [Display(Name = "Id")]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public int? Gender { get; set; }
        public int TrainnerId { get; set; }
        [Display(Name = "Trainner Name")]
        public string TrainnerName { get; set; }
        public int PlanId { get; set; }
        [Display(Name = "Subcription")]
        public string PlanName { get; set; }
        public bool? IsActive { get; set; }

        [Display(Name = "Registration")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("TrainnerId")]
        public virtual Traniner Traniner { get; set; }
        public virtual Plan Plan { get; set; }

    }
}
