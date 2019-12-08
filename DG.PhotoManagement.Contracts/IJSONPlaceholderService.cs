using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace DG.PhotoManagement.Contracts
{
    public interface IJSONPlaceholderService
    {
        [Get("/albums")]
        //Task<string> GetAlbumListAsync();
        Task<List<AlbumContract>> GetAlbumListAsync();
        [Get("/albums/{id}")]
        Task<AlbumContract> GetAlbumAsync(int id);

        [Get("/photos")]
        Task<List<AlbumContract>> GetPhotoListAsync();
        [Get("/photos/{id}")]
        Task<AlbumContract> GetPhotoAsync(int id);
    }
}
