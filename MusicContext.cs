using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using MusicHaven.Models;
namespace MusicHaven
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TipoAlbum> TiposAlbum { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoAlbum>().HasData(
                new TipoAlbum { TipoAlbumId = 1, NombreTipoAlbum = "Single" },
                new TipoAlbum { TipoAlbumId = 2, NombreTipoAlbum = "LP" },
                new TipoAlbum { TipoAlbumId = 3, NombreTipoAlbum = "EP" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    AlbumId = 1,
                    NombreAlbum = "White Pony",
                    NombreArtista = "Deftones",
                    Genero = "Nu Metal",
                    DescripcionAlbum = "Sample text",
                    TipoAlbumId = 2
                }
            );
        }
    }
}
