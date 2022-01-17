using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Service.ViewModel
{
    public class vwTraninerInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Registration Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateAt { get; set; }
        [Display(Name="Status")]
        public bool IsActive { get; set; }
    }
}
