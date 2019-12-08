using System.Collections.Generic;
using System.Threading.Tasks;
using DG.PhotoManagement.Contracts;

namespace DG.PhotoManagement.Business.Photos.Queries.Remote.GetListRemote
{
    public class GetPhotoRemoteListQuery
        : IGetPhotoRemoteListQuery
    {
        private readonly IJSONPlaceholderService _jSONPlaceholderService;

        public GetPhotoRemoteListQuery(
            IJSONPlaceholderService jSONPlaceholderService)
        {
            _jSONPlaceholderService = jSONPlaceholderService;
        }

        public async Task<List<PhotoContract>> GetQuery()
        {
            return await _jSONPlaceholderService.GetPhotoListAsync();
        }
    }
}
