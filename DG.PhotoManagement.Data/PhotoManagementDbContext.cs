using DG.PhotoManagement.Data.Configuration;
using DG.PhotoManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace DG.PhotoManagement.Data
{
	public class PhotoManagementDbContext
        : DbContext
    {
        public PhotoManagementDbContext(
			DbContextOptions<PhotoManagementDbContext> options)
            : base(options)
        { }

		public DbSet<Photo> Photos { get; set; }
		public DbSet<Album> Albums { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			LoadConfigurations(modelBuilder);
		}

		private void LoadConfigurations(ModelBuilder modelBuilder)
		{
			var configurations = typeof(PhotoManagementDbContext)
				.GetTypeInfo()
				.Assembly.ExportedTypes
				.Where(x => typeof(IEntityTypeConfiguration).IsAssignableFrom(x) && !x.GetTypeInfo().IsAbstract)
				.ToArray();

			foreach (var c in configurations)
			{
				var config = Activator.CreateInstance(c) as IEntityTypeConfiguration;
				config?.Configure(modelBuilder);
			}
		}
	}
}
