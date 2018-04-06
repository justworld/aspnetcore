using AutoMapper;
using Basic.Data.Domain;
using Basic.Model.Customers;

namespace Basic.WebCore
{
    public class AutoMapperInit
    {
        //单例初始化
        public static void Init()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Account, AccountModel>();
            });

        }
        
        //score初始化
        public static IMapper Create(IServiceProvider provider)
        {
            
        }
    }
}
