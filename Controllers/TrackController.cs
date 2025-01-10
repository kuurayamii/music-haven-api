using Microsoft.AspNetCore.Mvc;
using MusicHaven.Models;
using MusicHaven.Service;

namespace MusicHaven.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TrackController(ITrackService service) : ControllerBase
    {
        ITrackService trackService = service;

        [HttpGet]
        public IActionResult GetTracks() 
        {
            return Ok(trackService.GetTracks());
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetTrack(int id) 
        {
            var track = await trackService.GetTrack(id);

            Console.WriteLine(track);

            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        [HttpPost]
        public async Task <IActionResult> PostTrack(Track track) 
        {
            await trackService.PostTrack(track);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> PutTrack(int id, Track track) 
        {
            var trackAEditar = await trackService.PutTrack(id, track);

            if (trackAEditar == null)
            {
                return NotFound();
            }

            return Ok(trackAEditar);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteTrack(int id) 
        {
            var trackAEliminar = await trackService.DeleteTrack(id);

            if (trackAEliminar == null) { return NotFound(); }

            return Ok();
        }
    }
}
