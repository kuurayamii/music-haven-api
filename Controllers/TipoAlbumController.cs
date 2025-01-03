using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHaven;
using MusicHaven.Models;

namespace MusicHaven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAlbumController : ControllerBase
    {
        private readonly MusicContext _context;

        public TipoAlbumController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/TipoAlbum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAlbum>>> GetTiposAlbum()
        {
            return await _context.TiposAlbum.ToListAsync();
        }

        // GET: api/TipoAlbum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAlbum>> GetTipoAlbum(int id)
        {
            var tipoAlbum = await _context.TiposAlbum.FindAsync(id);

            if (tipoAlbum == null)
            {
                return NotFound();
            }

            return tipoAlbum;
        }

        // PUT: api/TipoAlbum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoAlbum(int id, TipoAlbum tipoAlbum)
        {
            if (id != tipoAlbum.TipoAlbumId)
            {
                return BadRequest();
            }

            _context.Entry(tipoAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoAlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoAlbum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoAlbum>> PostTipoAlbum([FromForm]TipoAlbum tipoAlbum)
        {
            _context.TiposAlbum.Add(tipoAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoAlbum", new { id = tipoAlbum.TipoAlbumId }, tipoAlbum);
        }

        // DELETE: api/TipoAlbum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoAlbum(int id)
        {
            var tipoAlbum = await _context.TiposAlbum.FindAsync(id);

            if (tipoAlbum == null)
            {
                return NotFound();
            }

            _context.TiposAlbum.Remove(tipoAlbum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoAlbumExists(int id)
        {
            return _context.TiposAlbum.Any(e => e.TipoAlbumId == id);
        }
    }
}
