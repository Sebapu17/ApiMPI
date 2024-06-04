namespace MPIapi.Models
{
    public class Order
    {
        // Crear todas las propiedades segun el JSON recibido
        public int Id { get; set; }
        public string Name { get; set; }
        public int cantProductos { get; set; }
    }
}
