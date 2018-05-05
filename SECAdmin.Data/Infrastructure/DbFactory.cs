
namespace SECAdmin.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SECAdminContext _dbContext;

        public SECAdminContext Init()
        {
            return _dbContext ?? (_dbContext = new SECAdminContext());
        }

        protected override void DisposeCore()
        {
            _dbContext.Dispose();
        }
    }
}
