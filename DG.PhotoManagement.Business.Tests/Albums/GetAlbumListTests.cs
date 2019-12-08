using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.PhotoManagement.Business.Albums.GetList;
using DG.PhotoManagement.Data;
using DG.PhotoManagement.Data.Entities;
using NUnit.Framework;

namespace DG.PhotoManagement.Business.Tests.Albums
{
    public class GetAlbumListTests
    {
        private IFixture _fixture;
        private PhotoManagementDbContext _dbContext;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [SetUp]
        public void SetUp()
        {
            _dbContext = DataContextTestHelper.MockDataContext<PhotoManagementDbContext>();

            _fixture.Inject(_dbContext);
        }

        [Test]
        public void ShouldGetAllAlbums()
        {
            // Arrange
            var albums = _fixture.CreateMany<Album>(5);

            _dbContext.Albums.AddRange(albums);
            _dbContext.SaveChanges();

            var query = _fixture.Create<GetAlbumList>();

            // Act

            var result = query.GetQuery();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 5);
        }
    }
}
