using Microsoft.EntityFrameworkCore;
using MusicHaven.Models;

namespace MusicHaven.Service
{
    public class TrackService(MusicContext dbContext) : ITrackService
    {
        MusicContext context = dbContext;

        //Get tracks
        public IEnumerable<Track> GetTracks()
        {

            return context.Tracks.Include(track => track.Album).ToList();

        }

        // Get Track (POR ID)
        public async Task<Track> GetTrack(int idTrack)
        {

            return await context.Tracks
                .Include(track => track.Album)
                .FirstOrDefaultAsync(track => track.TrackId == idTrack);

        }

        // Post track 
        public async Task PostTrack(Track track)
        {

            await context.AddAsync(track);
            await context.SaveChangesAsync();

        }

        // Modificar track/tracks (POR ID Y SU OBJETO EN MEMORIA)
        public async Task<Track> PutTrack(int idTrack, Track track) 
        {
            var trackAEditar = await context.Tracks.FindAsync(idTrack);

            if (trackAEditar == null)
            {
                return null;
            }

            trackAEditar.NumeroTrack = track.NumeroTrack;
            trackAEditar.NombreTrack = track.NombreTrack;
            await context.SaveChangesAsync();

            return trackAEditar;

        }

        // Eliminar un track (POR ID)
        public async Task<Track?> DeleteTrack(int idTrack) 
        {
            var trackAEliminar = context.Tracks.FirstOrDefault(track => track.TrackId == idTrack);

            if (trackAEliminar == null)
            {
                return null;
            }

            context.Tracks.Remove(trackAEliminar);
            await context.SaveChangesAsync();

            return trackAEliminar;

        }
    }

    public interface ITrackService
    {
        IEnumerable<Track> GetTracks();
        Task<Track> GetTrack(int idTrack);
        Task PostTrack(Track track);
        Task<Track> PutTrack(int trackId, Track track); 
        Task<Track?> DeleteTrack(int idTrack);
        
    }
}
