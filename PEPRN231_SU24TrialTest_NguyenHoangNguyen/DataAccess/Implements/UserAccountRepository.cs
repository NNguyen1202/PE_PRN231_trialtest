using BusinessObjects.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Implements
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly UserAcountDAO _dao;
        public UserAccountRepository()
        {
            _dao = UserAcountDAO.Instance;
        }
        public void Create(UserAccount entity)
        {
            _dao.Create(entity);
        }

        public void Delete(UserAccount entity)
        {
            _dao.Delete(entity);
        }

        public IQueryable<UserAccount> GetAll()
        {
            return _dao.GetAll();
        }

        public void Update(UserAccount entity)
        {
            _dao.Update(entity);
        }
    }
}
