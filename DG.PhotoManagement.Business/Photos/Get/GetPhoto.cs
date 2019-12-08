using System.Linq;
using System.Threading.Tasks;
using DG.PhotoManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace DG.PhotoManagement.Business.Photos.Get
{
    public class GetPhoto
        : IGetPhoto
    {
        private readonly PhotoManagementDbContext _dbContext;

        public GetPhoto(
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
