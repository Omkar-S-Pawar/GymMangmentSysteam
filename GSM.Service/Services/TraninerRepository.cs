using GSM.DAL.Data;
using GSM.DAL.Models;
using GSM.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSM.Service.Services
{
    public interface ITraniner : IDisposable
    {
        public IEnumerable<vwTraninerInfo> GetTraninerInfoAll();
        public vwTraninerInfo GetById(int id);
        public void Add(Traniner entity);
        public void UpdateTraniner(Traniner traniner);
        public void DeleteById(int id);
    }
    public class TraninerService : ITraniner
    {
        private readonly GMSContext _context;

        public TraninerService(GMSContext Context)
        {
            _context = Context;
        }

        public void Add(Traniner entity)
        {
            entity.CreatedBy = "Admin";
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdateDate = entity.CreatedDate;
            entity.UpdatedBy = entity.CreatedBy;

            _context.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var result = _context.MstTrainner.Find(id);
            _context.MstTrainner.Remove(result);
            _context.SaveChanges();
        }

        public vwTraninerInfo GetById(int id)
        {
            return _context.MstTrainner.Select(s => new vwTraninerInfo
            {
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                IsActive = s.IsActive
            }).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<vwTraninerInfo> GetTraninerInfoAll()
        {
            return _context.MstTrainner.Select(s => new vwTraninerInfo
            {
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                CreateAt = s.CreatedDate,
                IsActive = s.IsActive
            }).ToList();
        }

        public void UpdateTraniner(Traniner traniner)
        {
            var originalData = _context.MstTrainner.Where(w => w.Id == traniner.Id).FirstOrDefault();
            if (originalData != null)
            {
                originalData.Name = traniner.Name;
                originalData.Gender = traniner.Gender;
                originalData.IsActive = traniner.IsActive;
                originalData.UpdateDate = DateTime.UtcNow;
                originalData.UpdatedBy = "Admin";
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
