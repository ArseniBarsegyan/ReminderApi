using Microsoft.EntityFrameworkCore;

namespace Reminder.Data.Core
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions)
        {
            SchemaName = schemaName;
        }

        public string SchemaName { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}