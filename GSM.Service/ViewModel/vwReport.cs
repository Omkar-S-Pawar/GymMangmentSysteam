using GSM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Service.ViewModel
{
    public class vwReport
    {
        public List<vwUserInfo> ViewModelUsers { get; set; }
        public List<vwTraninerInfo> ViewModelTraniners { get; set; }
    }
}
