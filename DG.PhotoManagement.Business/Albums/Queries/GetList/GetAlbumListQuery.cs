using System.Linq;
using DG.PhotoManagement.Data;

namespace DG.PhotoManagement.Business.Albums.Queries.GetList
{
    public class GetAlbumListQuery
        : IGetAlbumListQuery
    {
        private readonly PhotoManagementDbContext _dbContext;

        public GetAlbumListQuery(
            PhotoManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<AlbumListModel> GetQuery()
        {
            return _dbContext.Albums
                .Select(p => new AlbumListModel
                {
                    Id = p.Id,
                    Title = p.Title
                });
        }
    }
}
