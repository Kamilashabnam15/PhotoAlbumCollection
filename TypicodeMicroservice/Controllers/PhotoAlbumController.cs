using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TypicodeMicroservice.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TypicodeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoAlbumController : ControllerBase
    {
        private readonly IPhotoAlbumRepository photoAlbumRepository;

        public PhotoAlbumController(IPhotoAlbumRepository photoAlbumRepository)
        {
            this.photoAlbumRepository = photoAlbumRepository;
        }
        // GET: api/<TypicodeController>
        [HttpGet]
        public async Task<ActionResult<PhotoAlbumModel>> GetPhotoAlbum()
        {
            try
            {
                return Ok(await photoAlbumRepository.GetPhotoAlbum());
                
            }
            catch
            {
                return StatusCode(500);
            }
            
        }
        // GET api/<TypicodeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoAlbumModel>> GetPhotoAlbumByUserID(int id)
        {
            try
            {
                return Ok(await photoAlbumRepository.GetPhotoAlbumByUserID(id));
            }

            catch
            {
                return StatusCode(500);
            }
           
        }

        
    }
}
