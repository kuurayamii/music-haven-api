using System.Text.Json.Serialization;

namespace MusicHaven.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int AlbumId { get; set; }
        public string TituloReview { get; set; }
        public string CuerpoReview { get; set; }
        public int Rating { get; set; }

        public virtual Album Album { get; set; }

 
    }
}
