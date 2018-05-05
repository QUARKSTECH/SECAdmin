using System;

namespace SECAdmin.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        SECAdminContext Init();
    }
}
