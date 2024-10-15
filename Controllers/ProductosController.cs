using Microsoft.AspNetCore.Mvc;
using asp_servicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Productos> Get()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-K5C1BNQ\\SQLEXPRESS;database=db_miniso;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();

            conexion.Guardar(new Productos()
            {
                Descripción = "sdlkfjdslkfjsldkf",
                Categoria = "Mapache"
            });
            conexion.SaveChanges();
            return conexion.Listar<Productos>();
        }
    }
}