using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StyleDAO
    {
        private static StyleDAO instance = null;
        private readonly WatercolorsPainting2024DBContext _dbContext;
        private readonly DbSet<Style> _dbSet;

        public StyleDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new WatercolorsPainting2024DBContext();
            }
            _dbSet = _dbContext.Set<Style>();
        }

        public static StyleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StyleDAO();
                }
                return instance;
            }
        }
        public IQueryable<Style> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public void Create(Style entity)
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
        public void Update(Style entity)
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
        public void Delete(Style entity)
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

