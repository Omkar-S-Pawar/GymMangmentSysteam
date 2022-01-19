using System;
using System.ComponentModel.DataAnnotations;

namespace GSM.Service.ViewModel
{
    public class vwTraninerInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        [Display(Name = "Registration Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateAt { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
