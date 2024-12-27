using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHaven.Models
{
    // Las clases no deberían llevar funciones a menos que se necesite una operación en
    // específico de estas, por lo que, no llevan las interfaces
    [Table("Album")]
    public class Album
    {
        // Propiedades de la clase con su constructor (Constructor primario)
        [Key]
        public int AlbumId { get; set; }


        [Required]
        [MaxLength(150)]
        public string NombreAlbum { get; set; }


        [Required]
        [MaxLength(150)]
        public string NombreArtista { get; set; }


        [Required]
        public string Genero { get; set; }


        public string DescripcionAlbum { get; set; }


        public int? TipoAlbumId { get; set; }
        public TipoAlbum? TipoAlbum { get; set; }
    }
}
