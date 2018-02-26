using AutoMapper;
using Basic.Data.Domain;
using Basic.Model.Customers;

namespace Basic.WebCore
{
    public static class MappingExtensions
    {
        public static AccountModel ToModel(this Account entity)
        {
            return Mapper.Map<Account, AccountModel>(entity);
        }
    }
}
