using System;
using System.Threading.Tasks;
using DG.PhotoManagement.Business.Photos.Get;
using Microsoft.AspNetCore.Mvc;

namespace DG.PhotoManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController
        : ControllerBase
    {
        private readonly IGetPhoto _getPhoto;

        public PhotoController(
            IGetPhoto getPhoto)
        {
            _getPhoto = getPhoto;
        }

        /// <summary>
        /// Endpoint resource to get a specific Photo
        /// </summary>
        /// <param name="id">argument of type integer</param>
        /// <returns>Photo object</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var photo = await _getPhoto.ExecuteAsync(id);

                return Ok(photo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
