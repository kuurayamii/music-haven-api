namespace MusicHaven.Models
{
    // Las clases no deberían llevar funciones a menos que se necesite una operación en
    // específico de estas, por lo que, no llevan las interfaces
    public class Album
    {
        // Propiedades de la clase con su constructor (Constructor primario)
        public int AlbumId { get; set; }
        public string NombreAlbum { get; set; }
        public string NombreArtista { get; set; }
        public int TipoAlbumId { get; set; }
        public TipoAlbum TipoAlbum { get; set; }
        public string Genero { get; set; }
        public string DescripcionAlbum { get; set; }
        public List<Track> Tracks { get; set; } // Un album puede tener muchos tracks pero muchos tracks pertenecen a un album.
        public List<Review> Reviews { get; set; }

    }
}
