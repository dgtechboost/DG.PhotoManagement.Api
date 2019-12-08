using System.Linq;
using System.Threading.Tasks;
using DG.PhotoManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace DG.PhotoManagement.Business.Photos.Queries.Get
{
    public class GetPhotoQuery
        : IGetPhotoQuery
    {
        private readonly PhotoManagementDbContext _dbContext;

        public GetPhotoQuery(
            PhotoManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<PhotoModel> ExecuteAsync(int id)
        {
            return _dbContext.Photos
                .Where(p => p.Id == id)
                .Select(p => new PhotoModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    AlbumId = p.AlbumId,
                    ThumbnailUrl = p.ThumbnailUrl,
                    Url = p.Url
                })
                .SingleOrDefaultAsync();
        }
    }
}
