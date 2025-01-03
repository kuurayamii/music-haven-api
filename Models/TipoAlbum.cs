using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicHaven.Models
{
    [Table("TipoAlbum")]
    public class TipoAlbum
    {
        [Key]
        public int TipoAlbumId { get; set; }

        [Required]
        public string NombreTipoAlbum { get; set; }

        [JsonIgnore]
        public virtual ICollection<Album>? Albums { get; set; }

    }
}
