namespace DG.PhotoManagement.Business.Photos.GetList
{
    public class PhotoListModel
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
