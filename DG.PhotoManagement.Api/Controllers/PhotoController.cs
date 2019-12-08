using System;
using System.Threading.Tasks;
using DG.PhotoManagement.Business.Photos.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace DG.PhotoManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController
        : ControllerBase
    {
        private readonly IGetPhotoQuery _getPhotoQuery;

        public PhotoController(
            IGetPhotoQuery getPhotoQuery)
        {
            _getPhotoQuery = getPhotoQuery;
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
                var photo = await _getPhotoQuery.ExecuteAsync(id);

                return Ok(photo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
