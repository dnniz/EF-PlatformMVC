using DEMO.Entity;
using System.Data.Entity;

namespace DEMO.Data
{
    // IDbSet<TEntity> 
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() 
            where TEntity : BaseEntity;

        int SaveChanges();
    }
}
