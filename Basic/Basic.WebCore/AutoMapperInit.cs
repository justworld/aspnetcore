using AutoMapper;
using Basic.Data.Domain;
using Basic.Model.Customers;
using System;

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
            //var accountService = provider.GetService(typeof(IAccountService)) as IAccountService;
            return new MapperConfiguration(config =>
            {
                //then you can use scope service
                config.CreateMap<Account, AccountModel>();
            }).CreateMapper();
        }
    }
}
