using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TypicodeMicroservice.Models
{
    public class PhotoAlbumRepository : IPhotoAlbumRepository
    {
        public async Task<IEnumerable<PhotoAlbumModel>> GetPhotoAlbum()
        {
                using (HttpClient httpClient = new HttpClient())
                {
                    var albummodel = JsonConvert.DeserializeObject<List<AlbumModel>>(
                                await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/albums")
                            );
                    var photomodel = JsonConvert.DeserializeObject<List<PhotoModel>>(
                            await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/photos")
                        );

                    var result = from album in albummodel
                                 join photos in photomodel on album.id equals photos.albumId
                                 select new PhotoAlbumModel()
                                 {
                                     userId = album.userId,
                                     albumId = album.id,
                                     albumTitle = album.title,
                                     photoId = photos.id,
                                     photoTitle = photos.title,
                                     photoURL = photos.url,
                                     photoThumbnailURL = photos.thumbnailUrl
                                 };
                    return result;
                
            }
            
        }

        public async Task<IEnumerable<PhotoAlbumModel>> GetPhotoAlbumByUserID(int id)
        {
                using (HttpClient httpClient = new HttpClient())
                {

                    var albummodel = JsonConvert.DeserializeObject<List<AlbumModel>>(
                                await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/albums")
                            );
                    var photomodel = JsonConvert.DeserializeObject<List<PhotoModel>>(
                            await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/photos")
                        );

                    var result = from album in albummodel
                                 join photos in photomodel on album.id equals photos.albumId
                                 where album.userId == id
                                 select new PhotoAlbumModel()
                                 {
                                     userId = album.userId,
                                     albumId = album.id,
                                     albumTitle = album.title,
                                     photoId = photos.id,
                                     photoTitle = photos.title,
                                     photoURL = photos.url,
                                     photoThumbnailURL = photos.thumbnailUrl
                                 };
                    return result;
                }
            
           
            
        }
    }
}
