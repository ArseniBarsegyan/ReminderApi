using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reminder.Data.Models;

namespace Reminder.Data.EF
{
    public class AppIdentityDbContext : IdentityDbContext<UserModel>
    {
        public AppIdentityDbContext(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions)
        {
            SchemaName = schemaName;
        }

        public string SchemaName { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<Note>("Notes", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<UserModel>("Users", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityRole>("Roles", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityUserClaim<string>>("UserClaims", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityUserRole<string>>("UserRoles", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityUserLogin<string>>("UserLogins", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityRoleClaim<string>>("RoleClaims", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityUserToken<string>>("UserToken", SchemaName));
        }
    }
}