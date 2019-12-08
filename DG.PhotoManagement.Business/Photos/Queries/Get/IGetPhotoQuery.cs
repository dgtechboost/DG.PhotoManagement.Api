using System.Threading.Tasks;

namespace DG.PhotoManagement.Business.Photos.Queries.Get
{
    public interface IGetPhotoQuery
    {
        Task<PhotoModel> ExecuteAsync(int id);
    }
}
