using Basic.Core;
using Basic.Data.Interface;

namespace Basic.Services
{
    public abstract class ServiceBase
    {
        protected readonly IDbAccessor _basicAccessor;
        protected readonly IWorkContext _workContext;
        protected ServiceBase(IDbAccessor basicAccessor, IWorkContext workContext)
        {
            _basicAccessor = basicAccessor;
            _workContext = workContext;
        }
    }
}
