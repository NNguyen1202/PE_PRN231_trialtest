using BusinessObjects.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implements
{
    public class StyleRepository : IStyleRepository
    {
        private readonly StyleDAO _dao;
        public StyleRepository()
        {
            _dao = StyleDAO.Instance;
        }

        public void Create(Style entity)
        {
            _dao.Create(entity);
        }

        public void Delete(Style entity)
        {
            _dao.Delete(entity);
        }

        public IQueryable<Style> GetAll()
        {
            return _dao.GetAll();
        }

        public void Update(Style entity)
        {
            _dao.Update(entity);
        }
    }
}
