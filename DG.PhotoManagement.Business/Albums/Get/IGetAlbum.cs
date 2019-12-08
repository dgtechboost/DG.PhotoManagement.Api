using System.Threading.Tasks;

namespace DG.PhotoManagement.Business.Albums.Get
{
    public interface IGetAlbum
    {
        Task<AlbumModel> ExecuteAsync(int id);
    }
}
