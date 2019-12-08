namespace DG.PhotoManagement.Business.AlbumPhotos.Queries.GetList
{
    public class PhotoListModel
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
