using System;
using System.Threading.Tasks;
using DG.PhotoManagement.Business.Albums.Get;
using Microsoft.AspNetCore.Mvc;

namespace DG.PhotoManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController
        : ControllerBase
    {
        private readonly IGetAlbum _getAlbum;

        public AlbumController(
            IGetAlbum getAlbum)
        {
            _getAlbum = getAlbum;
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
                var album = await _getAlbum.ExecuteAsync(id);

                return Ok(album);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
