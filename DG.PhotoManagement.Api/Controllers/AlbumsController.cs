using System;
using DG.PhotoManagement.Business.Albums.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace DG.PhotoManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController
        : ControllerBase
    {
        private readonly IGetAlbumListQuery _getAlbumListQuery;

        public AlbumsController(
            IGetAlbumListQuery getAlbumListQuery)
        {
            _getAlbumListQuery = getAlbumListQuery;
        }

        /// <summary>
        /// Endpoint resource to get all Albums
        /// </summary>
        /// <returns>List of Album objects</returns>
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                //var albums = _getAlbumList.GetQuery().ToList();

                var albums = _getAlbumListQuery.GetQuery();

                return Ok(albums);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
