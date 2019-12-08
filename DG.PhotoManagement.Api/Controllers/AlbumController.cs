using System;
using System.Threading.Tasks;
using DG.PhotoManagement.Business.Albums.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace DG.PhotoManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController
        : ControllerBase
    {
        private readonly IGetAlbumQuery _getAlbumQuery;

        public AlbumController(
            IGetAlbumQuery getAlbumQuery)
        {
            _getAlbumQuery = getAlbumQuery;
        }

        /// <summary>
        /// Endpoint resource to get a specific Album
        /// </summary>
        /// <param name="id">argument of type integer</param>
        /// <returns>Album object</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var album = await _getAlbumQuery.ExecuteAsync(id);

                return Ok(album);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
