using System;

namespace test1
{
    public class Venta
    {
        public Venta()
        {
        }

        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int VendedorId { get; set; }
        public int FacturaId { get; set; }
        public string descripcion { get; set; }
        public int ClienteId { get; set; }

        public int totalVentas { get; set; }
    }
}