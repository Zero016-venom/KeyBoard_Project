using ASSIGN_Data.IRepositories;
using ASSIGN_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Repositories
{
    public class AllRepositories<T> : IAllRepositories<T> where T : class
    {
        ASSIGNMENT_NET104Context _context;
        DbSet<T> _dbSet;

        public AllRepositories()
        {
            _context = new ASSIGNMENT_NET104Context();
        }

        public AllRepositories(ASSIGNMENT_NET104Context context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public bool CreateObj(T obj)
        {
            try
            {
                _dbSet.Add(obj);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteObj(T obj)
        {
            try
            {
                _dbSet.Remove(obj);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByID(dynamic id)
        {
            return _dbSet.Find(id);
        }

        public bool UpdateObj(T obj)
        {
            try
            {
                _dbSet.Update(obj);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
