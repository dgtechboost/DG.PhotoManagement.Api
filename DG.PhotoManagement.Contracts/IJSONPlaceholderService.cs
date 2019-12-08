using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace DG.PhotoManagement.Contracts
{
    public interface IJSONPlaceholderService
    {
        [Get("/albums")]
        Task<List<AlbumContract>> GetAlbumListAsync();
        [Get("/albums/{id}")]
        Task<AlbumContract> GetAlbumAsync(int id);

        [Get("/photos")]
        Task<List<PhotoContract>> GetPhotoListAsync();
        [Get("/photos/{id}")]
        Task<PhotoContract> GetPhotoAsync(int id);
    }
}
