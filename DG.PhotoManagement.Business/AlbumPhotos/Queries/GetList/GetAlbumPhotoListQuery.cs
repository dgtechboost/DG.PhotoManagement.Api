using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.PhotoManagement.Business.Albums.Queries.Remote.GetListRemote;
using DG.PhotoManagement.Business.Photos.Queries.Remote.GetListRemote;

namespace DG.PhotoManagement.Business.AlbumPhotos.Queries.GetList
{
    public class GetAlbumPhotoListQuery
        : IGetAlbumPhotoListQuery
    {
        private readonly IGetAlbumRemoteListQuery _getAlbumRemoteList;
        private readonly IGetPhotoRemoteListQuery _getPhotoRemoteList;

        public GetAlbumPhotoListQuery(
            IGetPhotoRemoteListQuery getPhotoRemoteList,
            IGetAlbumRemoteListQuery getAlbumRemoteList)
        {
            _getPhotoRemoteList = getPhotoRemoteList;
            _getAlbumRemoteList = getAlbumRemoteList;
        }

        public async Task<List<AlbumPhotoListModel>> GetQuery()
        {
            try
            {
                var photosTask = _getPhotoRemoteList.GetQuery();
                var albumsTask = _getAlbumRemoteList.GetQuery();

                await Task.WhenAll(
                     albumsTask,
                     photosTask
                     );

                var photos = await photosTask;
                var albums = await albumsTask;

                var result = from album in albums
                             join photo in photos on album.Id equals photo.AlbumId into albumPhotos
                             select new AlbumPhotoListModel
                             {
                                 Id = album.Id,
                                 Title = album.Title,
                                 UserId = album.UserId,
                                 Photos = albumPhotos
                                           .Where(x => x.AlbumId == album.Id)
                                           .Select(x => new PhotoListModel
                                           {
                                               Id = x.Id,
                                               AlbumId = x.AlbumId,
                                               ThumbnailUrl = x.ThumbnailUrl,
                                               Title = x.Title,
                                               Url = x.Url
                                           })
                             };

                return result?.ToList();
            }
            catch (AggregateException ex)
            {
                throw new AggregateException(ex);     
            }
        }
    }
}
