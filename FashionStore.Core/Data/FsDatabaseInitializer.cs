using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Core.Data
{
    public class FsDatabaseInitializer<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        public void InitializeDatabase(TContext context)
        {
            var dbExists = context.Database.Exists();
            var createTables = false;
            if (dbExists)
            {
                var numOfTables = 0;
                foreach (var t1 in context.Database.SqlQuery<int>("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE table_type = 'BASE TABLE' "))
                    numOfTables = t1;

                createTables = numOfTables == 0;
            }
            else
            {

                createTables = true;
            }

            if (createTables)
            {
                var dbCreationScript = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
                context.Database.ExecuteSqlCommand(dbCreationScript);

                context.SaveChanges();
            }
        }
    }
}
