using System.Linq;

namespace DG.PhotoManagement.Business.Photos.GetList
{
    public interface IGetPhotoList
    {
        IQueryable<PhotoListModel> GetQuery();
    }
}
