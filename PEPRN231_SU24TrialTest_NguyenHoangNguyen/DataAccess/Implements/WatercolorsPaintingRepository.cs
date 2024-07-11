using BusinessObjects.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implements
{
    public class  WatercolorsPaintingRepository: IWatercolorsPaintingRepository
    {
        private readonly WatercolorsPaintingDAO _dao;
        public WatercolorsPaintingRepository()
        {
            _dao = WatercolorsPaintingDAO.Instance;
        }

        public void Create(WatercolorsPainting entity)
        {
            _dao.Create(entity);
        }

        public void Delete(WatercolorsPainting entity)
        {
            _dao.Delete(entity);
        }

        public IQueryable<WatercolorsPainting> GetAll()
        {
            return _dao.GetAll();
        }

        public void Update(WatercolorsPainting entity)
        {
            _dao.Update(entity);
        }
    }
}
