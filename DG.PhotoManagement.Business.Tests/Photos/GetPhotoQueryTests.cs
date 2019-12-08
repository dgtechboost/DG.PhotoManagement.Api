using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.PhotoManagement.Business.Photos.Queries.Get;
using DG.PhotoManagement.Data;
using DG.PhotoManagement.Data.Entities;
using NUnit.Framework;

namespace DG.PhotoManagement.Business.Tests.Photos
{
    public class GetPhotoQueryTests
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
            _dbContext.Photos.AddRange(_fixture.CreateMany<Photo>());
            _dbContext.SaveChanges();

            _fixture.Inject(_dbContext);
        }

        [Test]
        public async Task ShouldGetSpecificPhoto()
        {
            // Arrange
            var photo = _fixture.Create<Photo>();

            _dbContext.Photos.Add(photo);
            _dbContext.SaveChanges();

            var query = _fixture.Create<GetPhotoQuery>();

            // Act

            var result = await query.ExecuteAsync(photo.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(photo.Id, result.Id);
            Assert.AreEqual(photo.Title, result.Title);
            Assert.AreEqual(photo.ThumbnailUrl, result.ThumbnailUrl);
            Assert.AreEqual(photo.Url, result.Url);
            Assert.AreEqual(photo.AlbumId, result.AlbumId);
        }
    }
}
