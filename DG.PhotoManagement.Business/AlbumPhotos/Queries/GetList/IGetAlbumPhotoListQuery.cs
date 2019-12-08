using System.Collections.Generic;
using System.Threading.Tasks;

namespace DG.PhotoManagement.Business.AlbumPhotos.Queries.GetList
{
    public interface IGetAlbumPhotoListQuery
    {
        Task<List<AlbumPhotoListModel>> GetQuery();
    }
}
