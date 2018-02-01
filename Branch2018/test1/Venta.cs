using System;

namespace test1
{
    public class Venta
    {
        public Venta()
        {
        }
        public int ventaId { get; set; }
        public int productoId { get; set; }
        public int vendedorId { get; set; }
        public int facturaId { get; set; }
        public string description { get; set; }
        public int clienteId { get; set; }
        public int totalVentas { get; set; }
    }
}