using System.Threading.Tasks;

namespace DG.PhotoManagement.Business.Albums.Queries.Get
{
    public interface IGetAlbumQuery
    {
        Task<AlbumModel> ExecuteAsync(int id);
    }
}
