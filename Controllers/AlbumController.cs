using Microsoft.AspNetCore.Mvc;
using MusicHaven.Service;
using MusicHaven.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicHaven.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlbumController(IAlbumService service) : ControllerBase
    {

        IAlbumService albumService = service;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(albumService.Get());
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetAlbum(int id)
        {

            var album = await albumService.GetAlbum(id);

            if (album == null) return NotFound();

            return Ok(album);
        }

        [HttpPost]
        public async Task <IActionResult> PostAlbum(Album album)
        {
            await albumService.PostAlbum(album);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, Album album) 
        {
            var albumAActualizar = await albumService.PutAlbum(id, album);
            return Ok(albumAActualizar);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id) 
        {
            // Por algun extraño motivo, si pongo lo de abajo me tira error. Saque la asincronia de la funcion en el servicio
            // y ya no suelta un error, pero, si no existe un objeto no retorna NotFound.

            // EDIT: Despues de mucho debugging, un rosario entre las manos y 5 padres nuestros
            // pude arreglar el bug agregando que retornase un objeto de tipo Album? en el servicio
            // lo que lo hace totalmente opcional devolver algo en especifico al controlador.
            // Gracias, Dios.

            var albumAEliminar = await albumService.DeleteAlbum(id);
            //System.Diagnostics.Debug.WriteLine($"Me llego esto desde AlbumService: {albumAEliminar}");
            if (albumAEliminar == null)
            {
                //System.Diagnostics.Debug.WriteLine("Pase por el condicional, soy null");
                return NotFound("El album consultado no existe.");
            }

            return NoContent(); //Retorna NoContent (Ok o 200 en el lado del cliente).

        }
    }
}
