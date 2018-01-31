using System;

namespace test1
{
    public class Producto
    {
        public Producto()
        {
        }

        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public double Precio { get; set; }
        public string DescripcionProducto { get; set; }
        public int stock { get; set; }

    }
}