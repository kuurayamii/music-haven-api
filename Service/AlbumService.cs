using Microsoft.AspNetCore.Http.HttpResults;
using MusicHaven.Models;
namespace MusicHaven.Service
{
    public class AlbumService : IAlbumService
    {
        MusicContext contexto;

        public AlbumService(MusicContext dbContext)
        {
            contexto = dbContext;
        }

        // Recuperar todos los albums
        public IEnumerable<Album> GetAlbums()
        {
            return contexto.Albums;
        }
        // Recuperar un album en especifico
        public async Task GetAlbum(int id)
        {
            await contexto.Albums.FindAsync(id);
        }
        // Registrar un album
        public async Task PostAlbum(Album album)
        {
            contexto.Add(album);
            await contexto.SaveChangesAsync();
        }
        // Modificar un album
        public async Task PutAlbum(int id, Album album)
        {
            var albumAActualizar = contexto.Albums.Find(id);

            if (albumAActualizar != null)
            {
                albumAActualizar.NombreAlbum = album.NombreAlbum;
                albumAActualizar.NombreArtista = album.NombreArtista;
                albumAActualizar.TipoAlbum = album.TipoAlbum;
                albumAActualizar.Genero = album.Genero;
                albumAActualizar.DescripcionAlbum = album.DescripcionAlbum;

                await contexto.SaveChangesAsync();
            }
        }

        // Eliminar un album
        public async Task DeleteAlbum(int id)
        {
            var albumAEliminar = contexto.Albums.Find(id);

            if (albumAEliminar != null) {
                contexto.Remove(albumAEliminar);

                await contexto.SaveChangesAsync();
            }
        }
    }

    public interface IAlbumService
    {
        IEnumerable<Album> GetAlbums(); //Obtiene todos los albums
        Task PostAlbum(Album album); // Registra un album
        Task PutAlbum(int id, Album album); // Actualiza un album
        Task DeleteAlbum(int id); // Borra un album
        Task GetAlbum(int id); // Obtiene un album
        

    }
}
