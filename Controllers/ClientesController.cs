using Microsoft.AspNetCore.Mvc;
using asp_servicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        [HttpGet(Name = "GetClientes")]
        public IEnumerable<Clientes> Get()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-K5C1BNQ\\SQLEXPRESS;database=db_miniso;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();

            conexion.Guardar(new Clientes()
            {
                Nombre = "Zack",
                Apellido = "Quiroz Miranda",
                Celular = "3135383179",
                Cumple = DateTime.Parse("2022/10/23")
            });
            conexion.SaveChanges();
            return conexion.Listar<Clientes>();
        }
    }
}