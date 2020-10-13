using Microsoft.EntityFrameworkCore;

namespace acades.data
{
    public abstract class BaseDbInitializer
    {
        protected readonly DataBaseContext context = null;

        public BaseDbInitializer(DataBaseContext context)
        {
            this.context = context;
        }

        public abstract bool Initialize();

        protected void OpenConnection(string tableName)
        {
            context.Database.OpenConnection();
#pragma warning disable EF1000 // Possible SQL injection vulnerability.
            _ = context.Database.ExecuteSqlCommand($"SET IDENTITY_INSERT dbo.{tableName} ON".ToString());
#pragma warning restore EF1000 // Possible SQL injection vulnerability.
        }

        protected void CloseConnection(string tableName)
        {
#pragma warning disable EF1000 // Possible SQL injection vulnerability.
            _ = context.Database.ExecuteSqlCommand($"SET IDENTITY_INSERT dbo.{tableName} OFF".ToString());
#pragma warning restore EF1000 // Possible SQL injection vulnerability.
            context.Database.CloseConnection();
        }

        protected void SaveChanges(string tableName)
        {
            try
            {
                this.OpenConnection(tableName);

                context.SaveChanges();
            }
            finally
            {
                this.CloseConnection(tableName);
            }
        }
    }
}
