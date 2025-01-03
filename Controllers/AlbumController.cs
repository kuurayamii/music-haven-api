using Microsoft.AspNetCore.Mvc;
using MusicHaven.Service;
using MusicHaven.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicHaven.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController(IAlbumService service) : ControllerBase
    {

        IAlbumService albumService = service;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(albumService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {

            var album = albumService.GetAlbum(id);

            if (album == null) return NotFound();

            return Ok(album);
        }

        [HttpPost]
        public IActionResult PostAlbum(Album album)
        {
            albumService.PostAlbum(album);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Album album) 
        {
            albumService.PutAlbum(id, album);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            albumService.DeleteAlbum(id);
            return NoContent();
        }
    }
}
