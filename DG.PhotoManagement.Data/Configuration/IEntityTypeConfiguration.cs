using Microsoft.EntityFrameworkCore;

namespace DG.PhotoManagement.Data.Configuration
{
    public interface IEntityTypeConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
