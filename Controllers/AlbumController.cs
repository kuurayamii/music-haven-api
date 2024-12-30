using Microsoft.AspNetCore.Mvc;
using MusicHaven.Service;
using MusicHaven.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicHaven.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController(MusicContext context) : ControllerBase
    {
        private readonly MusicContext _context = context;

        [HttpGet]
        public IActionResult GetAlbums()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult PostAlbum([FromForm] Album album)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromForm] int id, Album album) 
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromForm] int id) 
        {
            throw new NotImplementedException();
        }
    }
}
