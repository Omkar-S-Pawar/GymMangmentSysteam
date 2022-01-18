using GSM.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Service.ViewModel
{
    public class vwUserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public int? Gender { get; set; }
        public int TrainnerId { get; set; }
        [Display(Name = "Trainner")]
        public string TrainnerName { get; set; }
        [Display(Name = "Subcription")]
        public string PlanName { get; set; }
        public bool? IsActive { get; set; }

        [Display(Name = "Registration")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        public virtual Traniner Traniner {get;set;}

        public IList<User> Users { get; set; }
    }
}
