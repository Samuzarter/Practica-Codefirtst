using Microsoft.AspNetCore.Mvc;
using asp_servicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagosController : ControllerBase
    {
        [HttpGet(Name = "GetPagos")]
        public IEnumerable<Pagos> Get()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-K5C1BNQ\\SQLEXPRESS;database=db_miniso;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();

            conexion.Guardar(new Pagos()
            {
                Valor = 20000.00m,
                Fecha = DateTime.Parse("2024/10/16"),
                Metodo_Pago = "EFECTIVO",
                Producto = 2,
                Cliente = 2

            });
            conexion.SaveChanges();
            return conexion.Listar<Pagos>();
        }

        //Obtener total de pagos
        [HttpPost]
        public decimal TotalPagos()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-K5C1BNQ\\SQLEXPRESS;database=db_miniso;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();
            decimal total = 0;
            foreach (var x in conexion!.Listar<Pagos>())
            {
                total += x.Valor;
            }

            return total;

        }

        [HttpPost]
        public decimal PromedioPagosEfectivo()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-K5C1BNQ\\SQLEXPRESS;database=db_miniso;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();
            decimal total = 0;
            int cont = 0;
            foreach (var x in conexion!.Listar<Pagos>())
            {
                if (x.Metodo_Pago!.Equals("EFECTIVO"))
                {
                    cont++;
                    total += x.Valor;
                }
            }

            return total/cont;

        }

    }
}