using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Reminder.Migrations.Context;

namespace Reminder.Migrations.Factory
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReminderDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new IdentityContext(optionsBuilder.Options);
        }
    }
}