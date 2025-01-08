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
        IActionResult GetTracks() 
        {
            return Ok(trackService.GetTracks());
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetTrack(int trackId) 
        {
            var track = await trackService.GetTrack(trackId);

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

        //[HttpPut("{id}")]
        public async Task <IActionResult> PutTrack(int trackId, Track track) 
        {
            var trackAEditar = await trackService.PutTrack(trackId, track);

            if (trackAEditar == null)
            {
                return NotFound();
            }

            return Ok(trackAEditar);
        }

        //[HttpDelete("{id}")]
    }
}
