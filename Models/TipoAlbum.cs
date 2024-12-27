using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHaven.Models
{
    [Table("TipoAlbum")]
    public class TipoAlbum
    {
        [Key]
        public int TipoAlbumId { get; set; }

        [Required]
        public string NombreTipoAlbum { get; set; }

    }
}
