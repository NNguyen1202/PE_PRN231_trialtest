using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserAccountRepository
    {
        IQueryable<UserAccount> GetAll();
        void Create(UserAccount entity);
        void Update(UserAccount entity);
        void Delete(UserAccount entity);
    }
}
