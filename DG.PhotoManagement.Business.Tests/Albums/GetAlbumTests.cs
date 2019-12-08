using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.PhotoManagement.Business.Albums.Get;
using DG.PhotoManagement.Data;
using DG.PhotoManagement.Data.Entities;
using NUnit.Framework;

namespace DG.PhotoManagement.Business.Tests.Albums
{
    public class GetAlbumTests
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

            //add noise
            _dbContext.Albums.AddRange(_fixture.CreateMany<Album>());
            _dbContext.SaveChanges();

            _fixture.Inject(_dbContext);
        }

        [Test]
        public async Task ShouldGetSpecificAlbum()
        {
            // Arrange
            var album = _fixture.Create<Album>();

            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();

            var query = _fixture.Create<GetAlbum>();

            // Act

            var result = await query.ExecuteAsync(album.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(album.Id, result.Id);
            Assert.AreEqual(album.Title, result.Title);
        }
    }
}
