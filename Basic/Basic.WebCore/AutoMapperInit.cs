using AutoMapper;
using Basic.Data.Domain;
using Basic.Model.Customers;

namespace Basic.WebCore
{
    public class AutoMapperInit
    {
        public static void Init()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Account, AccountModel>();
            });

        }
    }
}
