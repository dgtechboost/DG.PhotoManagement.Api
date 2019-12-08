using System.Collections.Generic;
using System.Threading.Tasks;
using DG.PhotoManagement.Contracts;

namespace DG.PhotoManagement.Business.Albums.Queries.Remote.GetListRemote
{
    public interface IGetAlbumRemoteListQuery
    {
        Task<List<AlbumContract>> GetQuery();
    }
}
