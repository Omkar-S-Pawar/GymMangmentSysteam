using GSM.DAL.Data;
using GSM.Service.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Service.Services
{
    public interface IReportService : IDisposable
    {
        List<int> AdminDashboradCount();
    }
    public class ReportService : IReportService
    {
        private readonly GMSContext _context;

        public ReportService(GMSContext context)
        {
            _context = context;
        }
        public List<int> AdminDashboradCount()
        {
            var arlist1 = new List<int>
            {
                _context.MstUser.Where(x=>x.IsActive==true).Count(),
                _context.MstUser.Where(x => x.CreatedDate.Equals(DateTime.Now)).Count(),
                _context.MstUser.Where(x => x.CreatedDate <= DateTime.Now).Count(),
                _context.MstTrainner.Count()
            };
            return arlist1;
        }

        public IEnumerable<vwReport> UserDetail()
        {
            var data = from u in _context.MstUser                    
                       select new vwReport
                       {
                          User=u
                       };

            return data.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
