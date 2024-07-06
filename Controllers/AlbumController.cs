using EvaluacionMusicaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace EvaluacionMusicaAPI.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]

    public class AlbumController : Controller
    {
        private readonly EvaluacionMusicaDbContext _context;

        public class AlbumBusqueda
        {
            public string Busqueda { get; set; }
        }
         
        public AlbumController(EvaluacionMusicaDbContext context)
        {
            _context = context;

            if (context.Albums.Any())
            {
                return;  
            }


            _context.Albums.AddRange(
                new Album
                {

                    Nombre = "Metaphorical Music Vol. 2",
                    Artista = "Nujabes",
                    Precio = 99,
                    Img = "https://m.media-amazon.com/images/I/71HqxZIaRHS._UF1000,1000_QL80_.jpg"
                },
                new Album
                {

                    Nombre = "Modal Soul",
                    Artista = "Nujabes",
                    Precio = 99,
                    Img = "https://m.media-amazon.com/images/I/51g8QBRCkvL._UF1000,1000_QL80_.jpg"
                },
                new Album
                {
                    Nombre = "Operation: Doomsday",
                    Artista = "MF DOOM",
                    Precio = 120,
                    Img = "https://m.media-amazon.com/images/I/816St1GgpdL._UF1000,1000_QL80_.jpg"
                },
                new Album
                {
                    Nombre = "Mm.. Food",
                    Artista = "MF DOOM",
                    Precio = 150,
                    Img = "https://m.media-amazon.com/images/I/61IhnFgGQPL._UF1000,1000_QL80_.jpg"
                },
                new Album
                {
                    Nombre = "Take Me to Your Leader",
                    Artista = "MF DOOM",
                    Precio = 150,
                    Img = "https://m.media-amazon.com/images/I/61IhnFgGQPL._UF1000,1000_QL80_.jpg"
                }
            );

            _context.SaveChanges();
        }

        [HttpGet("{busqueda}")]
        public async Task<ActionResult<IEnumerable<Album>>> BuscarAlbum(string busqueda)
        {
            // Buscar al usuario en la base de datos por email y contraseña
            return await _context.Albums.Where(u => u.Nombre.Contains(busqueda)).ToListAsync();

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> ObtenerAlbumes()
        {
            // Buscar al usuario en la base de datos por email y contraseña
            return await _context.Albums.Select(album => new Album { 
                Id = album.Id,
                Nombre = album.Nombre,
                Artista = album.Artista,
                Precio = album.Precio, 
                Img = album.Img,
                
            }).ToListAsync();
        }
    }

    

}
