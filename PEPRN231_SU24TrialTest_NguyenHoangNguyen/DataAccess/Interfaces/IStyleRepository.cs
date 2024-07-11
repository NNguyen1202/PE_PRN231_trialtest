using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IStyleRepository
    {
        IQueryable<Style> GetAll();
        void Create(Style entity);
        void Update(Style entity);
        void Delete(Style entity);
    }
}
