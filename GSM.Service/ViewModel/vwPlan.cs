using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Service.ViewModel
{
    public class vwPlan
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}
