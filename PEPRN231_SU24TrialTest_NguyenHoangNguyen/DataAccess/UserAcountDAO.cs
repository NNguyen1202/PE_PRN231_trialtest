using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserAcountDAO
    {
        private static UserAcountDAO instance = null;
        private readonly WatercolorsPainting2024DBContext _dbContext;
        private readonly DbSet<UserAccount> _dbSet;

        public UserAcountDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new WatercolorsPainting2024DBContext();
            }
            _dbSet = _dbContext.Set<UserAccount>();
        }

        public static UserAcountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserAcountDAO();
                }
                return instance;
            }
        }
        public IQueryable<UserAccount> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public void Create(UserAccount entity)
        {
            try
            {
                _dbSet.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _dbContext.ChangeTracker.Clear();
            }
        }
        public void Update(UserAccount entity)
        {
            try
            {
                var tracker = _dbSet.Attach(entity);
                tracker.State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _dbContext.ChangeTracker.Clear();
            }
        }
        public void Delete(UserAccount entity)
        {
            try
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _dbContext.ChangeTracker.Clear();
            }
        }
    }
}

