namespace SECAdmin.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private SECAdminContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _dbContext = _dbContext ?? _dbFactory.Init();
        }

        public SECAdminContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public void Commit()
        {
            DbContext.Commit();
        }
        public void Test()
        {
            DbContext.Commit();
        }
    }
}
