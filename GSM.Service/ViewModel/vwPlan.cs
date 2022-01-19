using System;
using System.ComponentModel.DataAnnotations;

namespace GSM.Service.ViewModel
{
    public class vwPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}
