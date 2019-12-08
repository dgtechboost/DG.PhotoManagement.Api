using System;
using System.Linq;
using DG.PhotoManagement.Business.Photos.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace DG.PhotoManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController
        : ControllerBase
    {
        private readonly IGetPhotoListQuery _getPhotoListQuery;
        public PhotosController(
            IGetPhotoListQuery getPhotoListQuery)
        {
            _getPhotoListQuery = getPhotoListQuery;
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
                var photos = _getPhotoListQuery.GetQuery().ToList();

                return Ok(photos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
