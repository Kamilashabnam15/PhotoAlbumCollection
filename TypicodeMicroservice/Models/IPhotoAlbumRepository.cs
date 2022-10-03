using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TypicodeMicroservice.Models
{
    public interface IPhotoAlbumRepository
    {
        Task<IEnumerable<PhotoAlbumModel>> GetPhotoAlbumByUserID(int id);
        Task<IEnumerable<PhotoAlbumModel>> GetPhotoAlbum();
    }
}
