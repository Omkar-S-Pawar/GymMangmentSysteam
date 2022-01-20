using GSM.DAL.Data;
using GSM.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSM.Service.Services
{
    public interface IReportService : IDisposable
    {
        List<int> AdminDashboradCount();
        IEnumerable<vwUserInfo> UserDetail();
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
            var data = _context.MstUser.ToList();
            var countList = new List<int>
            {
                data.Count(),
                data.Where(x => x.CreatedDate.Equals(DateTime.Now)).Count(),
                data.Where(x => x.SubcriptionDate >= DateTime.Now).Count(),
                _context.MstTrainner.Count()
            };
            return countList;
        }

        public IEnumerable<vwUserInfo> UserDetail()
        {
            var vwUser = (from mu in _context.MstUser
                          orderby mu.CreatedDate descending
                          select new vwUserInfo
                          {
                              UserId = mu.Id,
                              Name = mu.Name,
                              Email = mu.Email,
                              Phone = mu.PhoneNumber,
                              TrainnerId = mu.TrainnerId,
                              TrainnerName = mu.Traniner.Name,
                              PlanId = mu.PlanId,
                              Gender = mu.Gender,
                              IsActive = mu.IsActive,

                          }).ToList();

            return vwUser;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
