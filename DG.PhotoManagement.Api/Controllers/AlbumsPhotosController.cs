using System;
using System.Threading.Tasks;
using DG.PhotoManagement.Business.AlbumPhotos.Queries.GetList;
using DG.PhotoManagement.Business.AlbumPhotos.Queries.GetListByUserId;
using Microsoft.AspNetCore.Mvc;

namespace DG.PhotoManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsPhotosController
        : ControllerBase
    {
        private readonly IGetAlbumPhotoListQuery _getAlbumPhotoListQuery;
        private readonly IGetAlbumPhotoListByUserIdQuery _getAlbumPhotoListByUserIdQuery;

        public AlbumsPhotosController(
            IGetAlbumPhotoListQuery getAlbumPhotoListQuery,
            IGetAlbumPhotoListByUserIdQuery getAlbumPhotoListByUserIdQuery)
        {
            _getAlbumPhotoListQuery = getAlbumPhotoListQuery;
            _getAlbumPhotoListByUserIdQuery = getAlbumPhotoListByUserIdQuery;
        }

        /// <summary>
        /// Endpoint resource to get all AlbumsPhotos
        /// </summary>
        /// <returns>List of AlbumPhoto list of objects</returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var albumsWithPhotos = await _getAlbumPhotoListQuery.GetQuery();

                return Ok(albumsWithPhotos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Endpoint resource to get all AlbumPhotos based on UserId
        /// </summary>
        /// <returns>List of AlbumPhoto list of objects</returns>
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetListByUserId(int id)
        {
            try
            {
                var albumsWithPhotosByUserId = await _getAlbumPhotoListByUserIdQuery.ExecuteAsync(id);

                return Ok(albumsWithPhotosByUserId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
