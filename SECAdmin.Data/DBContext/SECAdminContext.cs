using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SECAdmin.Data.Configurations;
using SECAdmin.Entity;

namespace SECAdmin.Data
{
    public class SECAdminContext : DbContext//IdentityDbContext<IdentityUser>
    {
        public SECAdminContext()
            : base("SECAdmin")
        {
            Database.SetInitializer<SECAdminContext>(null);
        }

        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }

        #endregion

        public virtual void Commit()
        {
            SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            //modelBuilder.Configurations.Add(new UserRoleConfiguration());
            //modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ClientDetailConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
