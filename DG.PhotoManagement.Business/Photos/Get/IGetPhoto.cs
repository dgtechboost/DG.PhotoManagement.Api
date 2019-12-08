using System.Threading.Tasks;

namespace DG.PhotoManagement.Business.Photos.Get
{
    public interface IGetPhoto
    {
        Task<PhotoModel> ExecuteAsync(int id);
    }
}
