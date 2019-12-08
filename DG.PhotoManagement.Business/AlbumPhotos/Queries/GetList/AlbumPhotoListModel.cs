using System.Collections.Generic;

namespace DG.PhotoManagement.Business.AlbumPhotos.Queries.GetList
{
    public class AlbumPhotoListModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public IEnumerable<PhotoListModel> Photos { get; set; }
    }
}
