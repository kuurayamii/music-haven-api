using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHaven.Models;
namespace MusicHaven.Service
{
    public class AlbumService(MusicContext dbContext) : IAlbumService
    {

        MusicContext context = dbContext;

        public IEnumerable<Album> Get()
        /* 
        Esta funcion permite recuperar a traves de EF Core los datos dentro del modelo
        Se llama a traves del controlador "AlbumController", por lo que, la logica transaccional
        se separa de la logica de acceso a los distintos endpoints de la API.
            
        Args:
            None

        Returns:
            Retorna una lista del tipo "List<Album>" ya sea vacia o con Albums en su interior.
            Los albums recuperados poseen un objeto que se le relaciona, el cual es su tipo de album
            ya sea; LP, Single, EP, etc.
        */
        {
            return context.Albums.Include(album => album.TipoAlbum).ToList();
        }


        public async Task<Album> GetAlbum(int id)
        /* 
        Recupera un album en especifico segun su ID y lo retorna al usuario.

        Args:
            id (int): Id del album a buscar.

        Returns:
            List<Album>: Retorna el album al usuario que solicita revisar o ver informacion de ese album.
            Puede estar vacío o con un objeto.
        */
        {
            return await context.Albums
                .Include(album => album.TipoAlbum)
                .FirstOrDefaultAsync(album => album.AlbumId == id);
        }

        
        public async Task PostAlbum(Album album)
        /* 
        Registra un álbum en la base de datos.

        Args:
            album (Album): Objeto "Album" que proviene desde el controlador de la solución para crear el objeto..

        Returns:
            No retorna nada, puesto que, lo que retorna una respuesta según su éxito o su fallo será el controlador.
        */
        {
            context.Add(album);
            await context.SaveChangesAsync();
        }

        
        public async Task<Album?> PutAlbum(int id, Album album)
        /* 
        Actualiza un album según su ID.

        Args:
            id (int): Id del album a buscar para actualizar.
            album (Album): Objeto "Album" al que se le actualizarán los datos en memoria para su posterior actualización.

        Returns:
            albumAActualizar (Album): Retorna el album actualizado al usuario para que verifique que se han modificado
            los datos del objeto solicitado.
        */
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

        
        public async Task DeleteAlbum(int id)
        /* 
        Recupera un album segun su ID y lo elimina.

        Args:
            id (int): Id del album a buscar para eliminar.

        Returns:
            None.
        */
        {
            var albumAEliminar = context.Albums.FirstOrDefault(album => album.AlbumId == id);
            if (albumAEliminar == null)
            {
                return;
            }
            context.Albums.Remove(albumAEliminar);

            context.SaveChanges();

   
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
