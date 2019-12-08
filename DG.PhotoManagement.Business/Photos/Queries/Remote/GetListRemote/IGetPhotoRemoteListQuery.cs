using System.Collections.Generic;
using System.Threading.Tasks;
using DG.PhotoManagement.Contracts;

namespace DG.PhotoManagement.Business.Photos.Queries.Remote.GetListRemote
{
    public interface IGetPhotoRemoteListQuery
    {
        Task<List<PhotoContract>> GetQuery();
    }
}
