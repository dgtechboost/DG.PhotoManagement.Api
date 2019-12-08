using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using DG.PhotoManagement.Business.AlbumPhotos.Queries.GetListByUserId;
using DG.PhotoManagement.Business.Albums.Queries.Remote.GetListRemote;
using DG.PhotoManagement.Business.Photos.Queries.Remote.GetListRemote;
using DG.PhotoManagement.Contracts;
using Moq;
using NUnit.Framework;

namespace DG.PhotoManagement.Business.Tests.AlbumPhotos
{
    public class GetAlbumPhotoListByUserIdQueryTests
    {
        private IFixture _fixture;
        private Mock<IGetAlbumRemoteListQuery> _mockGetAlbumRemoteListQuery;
        private Mock<IGetPhotoRemoteListQuery> _mockGetPhotoRemoteListQuery;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _mockGetAlbumRemoteListQuery = _fixture.Freeze<Mock<IGetAlbumRemoteListQuery>>();
            _mockGetPhotoRemoteListQuery = _fixture.Freeze<Mock<IGetPhotoRemoteListQuery>>();
        }

        [Test]
        public async Task ShouldGetAllAlbumsAndTheirPhotosByUserId()
        {
            // Arrange

            var userId = 1;

            var albums = _fixture
                .Build<AlbumContract>()
                .With(x=>x.UserId, userId)
                .CreateMany(1).ToList();

            _mockGetAlbumRemoteListQuery
                .Setup(x => x.GetQuery())
                .ReturnsAsync(albums);

            var photos = _fixture
                .Build<PhotoContract>()
                .With(x => x.AlbumId, albums.Single().Id)
                .CreateMany(5).ToList();

            _mockGetPhotoRemoteListQuery
                .Setup(x => x.GetQuery())
                .ReturnsAsync(photos);

            var query = _fixture.Create<GetAlbumPhotoListByUserIdQuery>();

            // Act

            var result = await query.ExecuteAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(result.First().Photos.Count(), 5);
            Assert.AreEqual(result.First().UserId, userId);
        }
    }
}
