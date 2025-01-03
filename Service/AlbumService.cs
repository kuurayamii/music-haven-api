using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHaven.Models;
namespace MusicHaven.Service
    //TODO: Elimina, deja meter datos y consultar los albums
    // Pero aun no deja modificar por ID ni buscar por ID
    // Instalare lazy loading para ver si agarra la coleccion asi.
{
    public class AlbumService : IAlbumService
    {
        MusicContext context;

        public AlbumService(MusicContext dbContext)
        {
            context = dbContext;
        }

        // Recuperar todos los albums
        public IEnumerable<Album> Get()
        {
            return context.Albums.Include(album => album.TipoAlbum).ToList();
        }

        // Recuperar un album en especifico
        public async Task<Album> GetAlbum(int id)
        {
            return await context.Albums
                .Include(album => album.TipoAlbum)
                .FirstOrDefaultAsync(album => album.AlbumId == id);
            var album = await context.Albums
                .Include(album => album.TipoAlbum)
                .SingleAsync(album => album.AlbumId == id);
        }

        // Registrar un album
        public async Task PostAlbum(Album album)
        {
            context.Add(album);
            await context.SaveChangesAsync();
        }

        // Modificar un album
        public async Task<Album?> PutAlbum(int id, Album album)
        {
            var albumAActualizar = context.Albums.Find(id);

            if (albumAActualizar != null)
            {
                albumAActualizar.NombreAlbum = album.NombreAlbum;
                albumAActualizar.NombreArtista = album.NombreArtista;
                albumAActualizar.TipoAlbum = album.TipoAlbum;
                albumAActualizar.Genero = album.Genero;
                albumAActualizar.DescripcionAlbum = album.DescripcionAlbum;
                albumAActualizar.TipoAlbumId = album.TipoAlbumId;

                await context.SaveChangesAsync();
            }

            return albumAActualizar;
        }

        // Eliminar un album
        public async Task DeleteAlbum(int id)
        {
            var albumAEliminar = context.Albums.Find(id);
            context.Albums.Remove(albumAEliminar);

            await context.SaveChangesAsync();
   
        }
    }

    public interface IAlbumService
    {
        IEnumerable<Album> Get(); //Obtiene todos los albums
        Task<Album> GetAlbum(int id); // Obtiene un album
        Task PostAlbum(Album album); // Registra un album
        Task<Album?> PutAlbum(int id, Album album); // Actualiza un album
        Task DeleteAlbum(int id); // Borra un album
        
        

    }
}
