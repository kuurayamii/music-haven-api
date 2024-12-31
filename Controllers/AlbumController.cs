using Microsoft.AspNetCore.Mvc;
using MusicHaven.Service;
using MusicHaven.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicHaven.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController(MusicContext context) : ControllerBase
    {

        private readonly MusicContext _context = context;

        [HttpGet]
        public async Task <ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {
            var album = _context.Albums.Find(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);

        }

        [HttpPost]
        public IActionResult PostAlbum([FromForm] Album album)
        {
            try
            {
                _context.Albums.Add(album);
                return Ok(album);
            }
            catch (Exception err) 
            {
                throw err; // Agarra la excepcion y la muestra por consola
            }
            

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromForm] int id, Album album) 
        {
            var albumAActualizar = _context.Albums.Find(id);

            if (albumAActualizar == null) return NotFound();
            try 
            { 
                albumAActualizar.AlbumId = album.AlbumId;
                albumAActualizar.NombreAlbum = album.NombreAlbum;
                albumAActualizar.NombreArtista = album.NombreArtista;
                albumAActualizar.Genero = album.Genero;
                albumAActualizar.DescripcionAlbum = album.DescripcionAlbum;
                albumAActualizar.TipoAlbumId = album.TipoAlbumId;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err) 
            { 
                throw err;
            }

            
            

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromForm] int id) 
        {
            var album = _context.Albums.Find(id);

            if (album == null )
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            return Ok();
        }
    }
}
