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
        public IEnumerable<vwUserInfo> GetUsersForAdminReport(string name, string email, string txtFromDate, string txttoDate, int Gender, int IsActive);
        public IEnumerable<vwUserInfo> GetUserById(string id);
        public vwUserInfo GetById(string id);
        public vwUserInfo GetByUserName(string email);
        public void UpdateUser(User user);
        public void UpdateUser(vwUserInfo viewUser,string updateBy);
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
                UserId = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.PhoneNumber,
                Gender = s.Gender,
                Age = s.Age,
                TrainnerName = s.Traniner.Name,
                PlanName = s.Plan.Name,
                CreatedDate = s.CreatedDate
            }).ToList();
        }
        public void UpdateUser(User user)
        {
            var originalData = _context.MstUser.Where(w => w.Email == user.Email).FirstOrDefault();
            if (originalData != null)
            {
                originalData.Name = user.Name;
                originalData.Email = user.Email;
                originalData.PhoneNumber = user.PhoneNumber;
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
        public void UpdateUser(vwUserInfo viewUser,string updateBy)
        {
           
            var originalData = _context.MstUser.Where(w => w.Email == viewUser.Email).FirstOrDefault();
           if (originalData != null)
            {
                originalData.Name = viewUser.Name;
                originalData.PhoneNumber = viewUser.Phone;
                originalData.Age = viewUser.Age;
                originalData.Gender = viewUser.Gender;
                originalData.UpdateDate = DateTime.UtcNow;
                originalData.UpdatedBy = updateBy;
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
            return GetUserInfoAll().FirstOrDefault(x => x.Email == email);
        }

        public vwUserInfo GetById(string id)
        {
            return GetUserById(id).FirstOrDefault(x => x.UserId == id);
        }
        public IEnumerable<vwUserInfo> GetUserById(string id)
        {
            return _context.MstUser.Where(x => x.Id == id).Select(s => new vwUserInfo
            {
                UserId = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.PhoneNumber,
                Gender = s.Gender,
                Age = s.Age,
                TrainnerId = s.TrainnerId,
                TrainnerName = s.Traniner.Name,
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
        public IEnumerable<vwUserInfo> GetUsersForAdminReport(string name, string email, string txtFromDate, string txttoDate, int Gender, int IsActive)
        {
            List<vwUserInfo> result = GetUserInfoAll().ToList();

            if (name != null)
            {
                result = result.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            if (email != null)
            {
                result = result.Where(s => s.Email.Contains(email)).ToList();
            }
            if (txtFromDate != null && txttoDate != null)
            {
                result = result.Where(s => s.CreatedDate >= Convert.ToDateTime(txtFromDate) && s.CreatedDate <= Convert.ToDateTime(txttoDate)).ToList();
            }
            if (Gender != 0)
            {
                result = result.Where(s => s.Gender.Equals(Gender)).ToList();
            }
            if (IsActive != 0)
            {
                result = result.Where(s => s.Gender.Equals(IsActive)).ToList();
            }

            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}