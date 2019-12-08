using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DG.PhotoManagement.Data.Configuration
{
    public abstract class EntityTypeConfiguration<TEntity> :
        IEntityTypeConfiguration,
        IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        public virtual void Configure(ModelBuilder builder)
        {
            builder.ApplyConfiguration(this);
        }
    }
}
