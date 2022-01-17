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
    public interface IWorkoutService : IDisposable
    {
        public IEnumerable<vwUserWorkout> GetUserWorkout();
        public List<vwWorkout> GetList();
        public IEnumerable<vwUserWorkout> GetWorkoutByUserId(int id);
        public vwUserWorkout GetById(int id);
        public void Add(UserWorkoutDay entity);
        public void UpdateUserWorkout(vwUserWorkout userWorkout);
        public void DeleteUserWorkoutById(int id);
    }
    public class WorkoutService : IWorkoutService
    {
        private readonly GMSContext _context;

        public WorkoutService(GMSContext context)
        {
            _context = context;
        }

        public void Add(UserWorkoutDay entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public List<vwWorkout> GetList()
        {
            return _context.WorkoutDays.Select(s => new vwWorkout { Id = s.Id, Name = s.Name }).ToList();
            //return _context.UserWorkoutDays.Select(s => new vwUserWorkout
            //{
            //    Id = s.Id,
            //    UserName = _context.MstUser.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
            //    WorkoutDay = _context.WorkoutDays.Where(x => x.Id == s.WorkId).FirstOrDefault().Name
            //}).ToList();
        }

        public void DeleteUserWorkoutById(int id)
        {
            var result = _context.UserWorkoutDays.Find(id);
            _context.UserWorkoutDays.Remove(result);
            _context.SaveChanges();
        }

        public vwUserWorkout GetById(int id)
        {
            return _context.UserWorkoutDays.Select(s => new vwUserWorkout
            {
                Id = s.Id,
                UserName = _context.MstUser.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
                WorkoutDay = _context.WorkoutDays.Where(x => x.Id == s.WorkId).FirstOrDefault().Name,
                CreatedDate = s.CreatedDate,
                IsActive = s.IsActive
            }).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<vwUserWorkout> GetUserWorkout()
        {
            return _context.UserWorkoutDays.Select(s => new vwUserWorkout
            {
                Id = s.Id,
                UserName = _context.MstUser.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
                WorkoutDay = _context.WorkoutDays.Where(x => x.Id == s.WorkId).FirstOrDefault().Name,
                CreatedDate = s.CreatedDate,
                IsActive = s.IsActive
            });
        }

        public IEnumerable<vwUserWorkout> GetWorkoutByUserId(int id)
        {
            return _context.UserWorkoutDays.Where(x => x.UserId == id).Select(s => new vwUserWorkout
            {
                Id = s.Id,
                UserName = _context.MstUser.Where(x => x.Id == s.UserId).FirstOrDefault().Name,
                WorkoutDay = _context.WorkoutDays.Where(x => x.Id == s.WorkId).FirstOrDefault().Name,
                CreatedDate = s.CreatedDate,
                IsActive = s.IsActive
            });
        }

        public void UpdateUserWorkout(vwUserWorkout userWorkout)
        {
            var originalData = _context.UserWorkoutDays.Where(w => w.Id == userWorkout.Id).FirstOrDefault();
            if (originalData != null)
            {
                originalData.WorkId = userWorkout.WorkId;
                originalData.UserId = userWorkout.UserId;
                originalData.IsActive = userWorkout.IsActive;
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
