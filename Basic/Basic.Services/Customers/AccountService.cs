using Basic.Data.Domain;
using Basic.Data.Interface;
using System.Linq;

namespace Basic.Services.Customers
{
    public class AccountService : IAccountService
    {
        #region ctor
        private readonly IDbAccessor _baseAccessor;
        public AccountService(IDbAccessor baseAccessor)
        {
            _baseAccessor = baseAccessor;
        }
        #endregion

        public Account GetById(int id)
        {
            return null;
        }

        public Account GetByUserName(string userName)
        {
            return _baseAccessor.Get<Account>().FirstOrDefault(i => i.UserName == userName);
        }

        public IQueryable<Account> GetList()
        {
            return null;
        }
    }
}
