using Microsoft.EntityFrameworkCore;
using System;

namespace DG.PhotoManagement.Business.Tests
{
    public class DataContextTestHelper
    {
        public static T MockDataContext<T>(
           string databaseName = null) where T : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder.EnableSensitiveDataLogging();

            var options = optionsBuilder
                .UseInMemoryDatabase(databaseName: databaseName ?? Guid.NewGuid().ToString())
                .Options;

            var instance = Activator.CreateInstance(typeof(T), new[] { options });
            return instance as T;
        }
    }
}
