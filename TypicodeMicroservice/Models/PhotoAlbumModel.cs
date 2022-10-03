using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TypicodeMicroservice.Models
{
    public class PhotoAlbumModel
    {
        public int userId { get; set; }
        public int albumId { get; set; }
        public string albumTitle { get; set; }
        public int photoId { get; set; }
        public string photoTitle { get; set; }
        public string photoURL { get; set; }
        public string photoThumbnailURL { get; set; }
    }
}
