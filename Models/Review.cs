﻿using System.Text.Json.Serialization;

namespace MusicHaven.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string TituloReview { get; set; }
        public string CuerpoReview { get; set; }
        public int Rating { get; set; }

        [JsonIgnore]
        public ICollection<Album> Albums { get; set; } // Navegacion a tabla donde tiene su FK
 
    }
}
