namespace MusicHaven.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int NumeroTrack { get; set; }
        public string NombreTrack { get; set; }
        

    }
}
