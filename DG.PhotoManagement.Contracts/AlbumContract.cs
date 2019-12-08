using Newtonsoft.Json;

namespace DG.PhotoManagement.Contracts
{
    public class AlbumContract
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
