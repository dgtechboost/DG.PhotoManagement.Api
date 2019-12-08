using DG.PhotoManagement.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DG.PhotoManagement.Data.Configuration
{
    public abstract class BaseEntityTypeConfiguration<TEntity> :
        EntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
