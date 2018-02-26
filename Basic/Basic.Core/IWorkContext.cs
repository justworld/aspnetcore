using Basic.Data.Domain;
using Microsoft.AspNetCore.Http;

namespace Basic.Core
{
    public interface IWorkContext
    {
        HttpContext CurrentHttpContext { get; }

        Account CurrentAccount { get; set; }
    }
}
