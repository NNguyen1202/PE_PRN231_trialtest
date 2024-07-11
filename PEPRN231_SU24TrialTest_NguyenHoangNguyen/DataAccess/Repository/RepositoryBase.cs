using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RepositoryBase<T> where T : class
    {
        private readonly WatercolorsPainting2024DBContext watercolorPainting2024DbContext;

        public RepositoryBase()
        {
            watercolorPainting2024DbContext = new WatercolorsPainting2024DBContext();
        }

        public void Create(T entity)
        {
            watercolorPainting2024DbContext.Set<T>().Add(entity);
            watercolorPainting2024DbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            watercolorPainting2024DbContext.Set<T>().Remove(entity);
            watercolorPainting2024DbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return watercolorPainting2024DbContext.Set<T>();
        }

        public void Update(T entity)
        {
            watercolorPainting2024DbContext.Set<T>().Attach(entity);
            watercolorPainting2024DbContext.Entry(entity).State = EntityState.Modified;
            watercolorPainting2024DbContext.SaveChanges();
        }

    }
}
