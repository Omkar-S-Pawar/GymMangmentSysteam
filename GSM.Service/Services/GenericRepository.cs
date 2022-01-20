using GSM.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSM.Service.Services
{
    public interface IService<T> : IDisposable where T : class
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> GetList();
        T GetById(int Id);
    }
    public class GenericService<T> : IService<T> where T : class
    {
        private readonly GMSContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericService(GMSContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T obj)
        {
            _dbSet.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public T GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public IEnumerable<T> GetList()
        {
            return _dbSet.ToList();
        }

        public void Update(T obj)
        {
            _dbSet.Update(obj);
            _context.SaveChanges();
        }
    }
}
