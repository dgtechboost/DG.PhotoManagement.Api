using System;
using System.Linq;
using DG.PhotoManagement.Business.Photos.GetList;
using Microsoft.AspNetCore.Mvc;

namespace DG.PhotoManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController
        : ControllerBase
    {
        private readonly IGetPhotoList _getPhotoList;
        public PhotosController(
            IGetPhotoList getPhotoList)
        {
            _getPhotoList = getPhotoList;
        }

        /// <summary>
        /// Endpoint resource to get all Photos
        /// </summary>
        /// <returns>List of Photo objects</returns>
        [HttpGet()]
        public IActionResult GetList()
        {
            try
            {
                var photos = _getPhotoList.GetQuery().ToList();

                return Ok(photos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
