using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Reminder.Migrations.Context;

namespace Reminder.Migrations.Factory
{
    public class BaseContextFactory : IDesignTimeDbContextFactory<BaseContext>
    {
        public BaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReminderDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new BaseContext(optionsBuilder.Options);
        }
    }
}