using DG.PhotoManagement.Contracts;
using DG.PhotoManagement.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DG.PhotoManagement.Business.Albums.Queries.Get
{
    public class GetAlbumQuery
        : IGetAlbumQuery
    {
        private readonly PhotoManagementDbContext _dbContext;
        private readonly IJSONPlaceholderService _jSONPlaceholderService;

        public GetAlbumQuery(
            PhotoManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<AlbumModel> ExecuteAsync(int id)
        {
            return _dbContext.Albums
                .Where(a => a.Id == id)
                .Select(a => new AlbumModel
                {
                    Id = a.Id,
                    Title = a.Title
                })
                .SingleOrDefaultAsync();
        }
    }
}
