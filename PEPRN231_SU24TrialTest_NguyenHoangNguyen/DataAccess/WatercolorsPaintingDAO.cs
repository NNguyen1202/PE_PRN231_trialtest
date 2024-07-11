using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class WatercolorsPaintingDAO
    {
        private static WatercolorsPaintingDAO instance = null;
        private readonly WatercolorsPainting2024DBContext _dbContext;
        private readonly DbSet<WatercolorsPainting> _dbSet;

        public WatercolorsPaintingDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new WatercolorsPainting2024DBContext();
            }
            _dbSet = _dbContext.Set<WatercolorsPainting>();
        }

        public static WatercolorsPaintingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WatercolorsPaintingDAO();
                }
                return instance;
            }
        }
        public IQueryable<WatercolorsPainting> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public void Create(WatercolorsPainting entity)
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
        public void Update(WatercolorsPainting entity)
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
        public void Delete(WatercolorsPainting entity)
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

