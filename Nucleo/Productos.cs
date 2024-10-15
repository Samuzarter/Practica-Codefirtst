using System.ComponentModel.DataAnnotations;

namespace asp_servicios.Nucleo
{
    public class Productos
    {
        [Key] public int Id { get; set; }
        public string? Descripción { get; set; }
        public string? Categoria { get; set; }


    }
}
