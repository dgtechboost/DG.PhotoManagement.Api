using System.Linq;

namespace DG.PhotoManagement.Business.Albums.Queries.GetList
{
    public interface IGetAlbumListQuery
    {
        IQueryable<AlbumListModel> GetQuery();
    }
}
