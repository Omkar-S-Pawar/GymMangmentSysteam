using GSM.DAL.Data;
using GSM.DAL.Models;
using GSM.Service.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Service.Services
{
    public interface ITraniner :IDisposable
    {
        public IEnumerable<vwTraninerInfo> GetTraninerInfoAll();
        public IEnumerable<vwTraninerInfo> GetTraninerById(int id);
        public vwTraninerInfo GetById(int id);
        public void Add(Traniner entity);
        public string GetTraninerName(int? id);
        public void UpdateTraniner(Traniner traniner);
        public void DeleteById(int id);
        public IEnumerable<vwUserInfo> GetUserByTranninerId(int TraninerId);
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
                Gender=s.Gender,
                IsActive = s.IsActive
            }).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<vwTraninerInfo> GetTraninerById(int id)
        {
            return _context.MstTrainner.Select(s => new vwTraninerInfo
            {
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                IsActive = s.IsActive
            });
        }

        public IEnumerable<vwTraninerInfo> GetTraninerInfoAll()
        {
            return _context.MstTrainner.Select(s => new vwTraninerInfo
            {
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                CreateAt=s.CreatedDate,
                IsActive = s.IsActive
            }).ToList();
        }

        public string GetUserNameById(int id)
        {
            return _context.MstUser.Find(id).Name;
        }

        public IEnumerable<vwUserInfo> GetUserByTranninerId(int TraninerId)
        {
            return _context.MstUser.Where(x => x.TrainnerId == TraninerId)
                .Select(s => new vwUserInfo
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Phone = s.Phone,
                    Gender = s.Gender,
                    Age = s.Age,
                    TrainnerName =GetTraninerName(s.TrainnerId),
                    IsActive = s.IsActive
                });
        }
        public string GetTraninerName(int? id)
        {
           return _context.MstTrainner.Where(x => x.Id == id).FirstOrDefault().Name;
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
