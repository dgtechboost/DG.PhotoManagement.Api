using System.Collections.Generic;

namespace DG.PhotoManagement.Business.AlbumPhotos.Queries.GetListByUserId
{
    public class AlbumPhotoListByUserIdModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public IEnumerable<PhotoListByUserIdModel> Photos { get; set; }
    }
}
