using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using MusicHaven.Models;
namespace MusicHaven
{
    public class MusicContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<TipoAlbum> TiposAlbum { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        //public DbSet<Review> Reviews { get; set; }

    }
}
