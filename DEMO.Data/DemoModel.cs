using DEMO.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Data
{
    public class DemoModel : DbContext, IDbContext
    {
        public DemoModel()
            : base("DemoBDModel")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>();

            base.OnModelCreating(modelBuilder);
        }


        public new IDbSet<TEntity> Set<TEntity>()
             where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}
//enable-migrations
//update-database -verbose