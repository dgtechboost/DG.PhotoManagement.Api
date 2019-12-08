namespace DG.PhotoManagement.Data.Entities
{
    public class Photo 
        : BaseEntity
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }

        public Album Album { get; set; }
    }
}
