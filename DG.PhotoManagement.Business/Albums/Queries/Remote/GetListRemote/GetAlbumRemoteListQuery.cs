using System.Collections.Generic;
using System.Threading.Tasks;
using DG.PhotoManagement.Contracts;

namespace DG.PhotoManagement.Business.Albums.Queries.Remote.GetListRemote
{
    public class GetAlbumRemoteListQuery
        : IGetAlbumRemoteListQuery
    {
        private readonly IJSONPlaceholderService _jSONPlaceholderService;

        public GetAlbumRemoteListQuery(
            IJSONPlaceholderService jSONPlaceholderService)
        {
            _jSONPlaceholderService = jSONPlaceholderService;
        }

        public async Task<List<AlbumContract>> GetQuery()
        {
            return await _jSONPlaceholderService.GetAlbumListAsync();
        }
    }
}
