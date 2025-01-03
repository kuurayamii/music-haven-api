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
        public async Task <IActionResult> GetAlbum(int id)
        {

            var album = await albumService.GetAlbum(id);

            if (album == null) return NotFound();

            return Ok(album);
        }

        [HttpPost]
        public async Task <IActionResult> PostAlbum(Album album)
        {
            await albumService.PostAlbum(album);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, Album album) 
        {
            var albumAActualizar = await albumService.PutAlbum(id, album);
            return Ok(albumAActualizar);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id) 
        {
            await albumService.DeleteAlbum(id);
            return Ok(albumService.Get()); //Retorna 200 (Ok) y muestra los datos existentes en la base de datos post eliminacion.
        }
    }
}
