using System.ComponentModel.DataAnnotations;

namespace MPIapi.Models.Dto
{
    public class OrderDto
    {
        // Crear todas las propiedades segun el JSON recibido
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]      // DataAnnotations ... (Es requerido, maximo de caracteres, etc)
        public string Name { get; set; }

        [Required]
        public int cantProductos { get; set; }
    }
}
