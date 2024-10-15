using System.ComponentModel.DataAnnotations;

namespace asp_servicios.Nucleo
{
    public class Pagos
    {
        [Key] public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
        public string? Metodo_Pago { get; set; }
        public int Producto { get; set; }
        public int Cliente { get; set; }

    }
}
