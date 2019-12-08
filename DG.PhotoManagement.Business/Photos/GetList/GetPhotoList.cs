using System.Linq;
using DG.PhotoManagement.Data;

namespace DG.PhotoManagement.Business.Photos.GetList
{
    public class GetPhotoList
        : IGetPhotoList
    {
        private readonly PhotoManagementDbContext _dbContext;

        public GetPhotoList(
            PhotoManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<PhotoListModel> GetQuery()
        {
            return _dbContext.Photos
                .Select(p => new PhotoListModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    AlbumId = p.AlbumId,
                    ThumbnailUrl = p.ThumbnailUrl
                });
        }
    }
}
