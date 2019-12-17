using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reminder.Data.Core
{
    public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        protected EntityTypeConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        public string SchemaName { get; }

        public abstract void Configure(EntityTypeBuilder<TEntity> entityTypeBuilder);
    }
}