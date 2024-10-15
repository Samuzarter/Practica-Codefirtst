using System.ComponentModel.DataAnnotations;

namespace asp_servicios.Nucleo
{
    public class Clientes
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Celular { get; set; }
        public DateTime Cumple { get; set; }
    }
}
