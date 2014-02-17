using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using FashionStore.Core;
using FashionStore.Core.Data;

namespace FashionStore.EFData
{
    public class FsObjectContext : DbContext, IDbContext
    {
        public FsObjectContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}
