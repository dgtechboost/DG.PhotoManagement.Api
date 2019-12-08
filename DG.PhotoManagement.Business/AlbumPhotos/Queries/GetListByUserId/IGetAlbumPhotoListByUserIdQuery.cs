using System.Collections.Generic;
using System.Threading.Tasks;

namespace DG.PhotoManagement.Business.AlbumPhotos.Queries.GetListByUserId
{
    public interface IGetAlbumPhotoListByUserIdQuery
    {
        Task<List<AlbumPhotoListByUserIdModel>> ExecuteAsync(int id);
    }
}
