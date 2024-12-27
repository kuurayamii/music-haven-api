using Microsoft.AspNetCore.Mvc;
using MusicHaven.Service;
using MusicHaven.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicHaven.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        IAlbumService albumService;

        [HttpGet]
        public IActionResult GetAlbums()
        {
            return Ok(albumService.GetAlbums());
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {
            var albumObtenido = albumService.GetAlbum(id);

            if (albumObtenido != null)
            {
                return Ok(albumObtenido);
            }
            
            return NotFound();
        }

        [HttpPost]
        public IActionResult PostAlbum([FromForm] Album album)
        {
            albumService.PostAlbum(album);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromForm] int id, Album album) 
        {
            albumService.PutAlbum(id, album);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromForm] int id) 
        {
            albumService.DeleteAlbum(id);
            return Ok();
        }
    }
}
