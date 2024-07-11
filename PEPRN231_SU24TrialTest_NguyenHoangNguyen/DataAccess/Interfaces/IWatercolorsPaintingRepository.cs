using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IWatercolorsPaintingRepository
    {
        IQueryable<WatercolorsPainting> GetAll();
        void Create(WatercolorsPainting entity);
        void Update(WatercolorsPainting entity);
        void Delete(WatercolorsPainting entity);
    }
}
