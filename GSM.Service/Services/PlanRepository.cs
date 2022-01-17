using GSM.DAL.Data;
using GSM.DAL.Models;
using GSM.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Service.Services
{
    public interface IPlanService :IDisposable
    {
        public IEnumerable<vwPlan> GetPlanInfoAll();
        public IEnumerable<vwPlan> GetPlanById(int id);
        public vwPlan GetById(int id);
        public void Add(Plan entity);
        public void UpdatePlan(vwPlan user);
        public void DeletePlanById(int id);
    }
    public class PlanService : IPlanService
    {
        private readonly GMSContext _context;
        public PlanService(GMSContext context)
        {
            _context = context;
        }
        public void Add(Plan entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void DeletePlanById(int id)
        {
            var result = _context.Plans.Find(id);
            _context.Plans.Remove(result);
            _context.SaveChanges();
        }

        public vwPlan GetById(int id)
        {
            return _context.Plans.Select(s => new vwPlan
            {
                Id = s.Id,
                Name = s.Name,
                CreatedDate=s.CreatedDate,
                IsActive = s.IsActive
            }).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<vwPlan> GetPlanById(int id)
        {
            return _context.Plans.Select(s => new vwPlan
            {
                Id = s.Id,
                Name = s.Name,
                CreatedDate = s.CreatedDate,
                IsActive = s.IsActive
            });
        }

        public IEnumerable<vwPlan> GetPlanInfoAll()
        {
            return _context.Plans.Select(s => new vwPlan
            {
                Id = s.Id,
                Name = s.Name,
                IsActive=s.IsActive,
                CreatedDate = s.CreatedDate
            }).ToList();
        }

        public void UpdatePlan(vwPlan entity)
        {
            var originalData = _context.Plans.Where(w => w.Id == entity.Id).FirstOrDefault();
            if (originalData != null)
            {
                originalData.Name = entity.Name;
                originalData.IsActive = entity.IsActive;
                originalData.UpdateDate = DateTime.UtcNow;
                originalData.UpdateBy = "Admin";
            };
            _context.Update(originalData);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
