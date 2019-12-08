using DG.PhotoManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DG.PhotoManagement.Data.Configuration
{
    public class PhotoConfiguration
        : BaseEntityTypeConfiguration<Photo>
    {
        public override void Configure(EntityTypeBuilder<Photo> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title).HasMaxLength(2000);
            builder.Property(x => x.Id).HasColumnType("SMALLINT");
        }
    }
}
