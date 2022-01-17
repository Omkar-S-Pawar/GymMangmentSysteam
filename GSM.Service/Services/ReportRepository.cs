using GSM.DAL.Data;
using GSM.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Service.Services
{
    public interface IReportService : IDisposable
    {
        List<vwUserInfo> vwUserInfos();
    }
    public class ReportService : IReportService
    {
        private readonly GMSContext _context;

        public ReportService(GMSContext context)
        {
            _context = context;
        }

        public List<vwUserInfo> vwUserInfos()
        {
            return _context.Set<vwUserInfo>().ToList();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
