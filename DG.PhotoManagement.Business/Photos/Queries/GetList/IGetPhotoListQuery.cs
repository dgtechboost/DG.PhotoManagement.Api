using System.Linq;

namespace DG.PhotoManagement.Business.Photos.Queries.GetList
{
    public interface IGetPhotoListQuery
    {
        IQueryable<PhotoListModel> GetQuery();
    }
}
