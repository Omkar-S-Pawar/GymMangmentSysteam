using GSM.DAL.Data;
using GSM.DAL.Models;
using GSM.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSM.Service.Services
{
    public interface IUserService : IDisposable
    {
        public IEnumerable<vwUserInfo> GetUserInfoAll();
        public IEnumerable<vwUserInfo> GetUserById(int id);
        public vwUserInfo GetById(int id);
        public vwUserInfo GetByUserName(string email);
        public void Add(User entity);
        public void UpdateUser(User user);
        public void DeleteUserById(int id);
        public IEnumerable<vwTraninerInfo> GetddlTraniner();
        public IEnumerable<vwPlan> GetddlPlan();
    }
    public class UserService : IUserService
    {
        private readonly GMSContext _context;

        public UserService(GMSContext DBContext)
        {
            _context = DBContext;
        }

        public IEnumerable<vwUserInfo> GetUserInfoAll()
        {
            return _context.MstUser.Select(s => new vwUserInfo
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Gender = s.Gender,
                Age = s.Age,
                TrainnerName = s.Traniner.Name,
                PlanName =s.Plan.Name,
                CreatedDate = (DateTime)s.CreatedDate
            }).ToList();
        }

        public void Add(User entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var originalData = _context.MstUser.Where(w => w.Id == user.Id).FirstOrDefault();
            if (originalData != null)
            {
                originalData.Name = user.Name;
                originalData.Email = user.Email;
                originalData.Phone = user.Phone;
                originalData.Age = user.Age;
                originalData.Gender = user.Gender;
                originalData.IsActive = user.IsActive;
                originalData.TrainnerId = user.TrainnerId;
                originalData.UpdateDate = DateTime.UtcNow;
                originalData.UpdatedBy = "Admin";
            };
            _context.Update(originalData);
            _context.SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            var result = _context.MstUser.Find(id);
            _context.MstUser.Remove(result);
            _context.SaveChanges();
        }

        public vwUserInfo GetByUserName(string email)
        {
            return _context.MstUser.Select(s => new vwUserInfo
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Gender = s.Gender,
                Age = s.Age,
                TrainnerName = s.Traniner.Name,
                PlanName = s.Plan.Name,
               
                IsActive = s.IsActive
            }).FirstOrDefault(x => x.Email == email);
        }

        public vwUserInfo GetById(int id)
        {
            return _context.MstUser.Select(s => new vwUserInfo
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Gender = s.Gender,
                Age = s.Age,
                TrainnerName = s.Traniner.Name,
                IsActive = s.IsActive
            }).FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<vwUserInfo> GetUserById(int id)
        {
            return _context.MstUser.Where(x => x.Id == id).Select(s => new vwUserInfo
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Gender = s.Gender,
                Age = s.Age,
                TrainnerName = _context.MstTrainner.Where(x => x.Id == s.TrainnerId).FirstOrDefault().Name,
                IsActive = s.IsActive
            });
        }
        public IEnumerable<vwTraninerInfo> GetddlTraniner()
        {
            return _context.MstTrainner.Where(x => x.IsActive == true).Select(s => new vwTraninerInfo
            {
                Id = s.Id,
                Name = s.Name
            });
        }
        public IEnumerable<vwPlan> GetddlPlan()
        {
            return _context.Plans.Where(x => x.IsActive == true).Select(s => new vwPlan
            {
                Id = s.Id,
                Name = s.Name
            });
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
