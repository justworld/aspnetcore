using Basic.Data.Domain;
using System.Linq;

namespace Basic.Services.Customers
{
    public interface IAccountService
    {
        Account GetById(int id);

        Account GetByUserName(string userName);

        IQueryable<Account> GetList();
    }
}
