using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.PhotoManagement.Business.Photos.GetList;
using DG.PhotoManagement.Data;
using DG.PhotoManagement.Data.Entities;
using NUnit.Framework;

namespace DG.PhotoManagement.Business.Tests.Photos
{
    public class GetPhotoListTests
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
        public void ShouldGetAllPhotos()
        {
            // Arrange
            var photos = _fixture.CreateMany<Photo>(5);

            _dbContext.Photos.AddRange(photos);
            _dbContext.SaveChanges();

            var query = _fixture.Create<GetPhotoList>();

            // Act

            var result = query.GetQuery();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 5);
        }
    }
}
