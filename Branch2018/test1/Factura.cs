
using System;

namespace test1
{
  public class Factura
    {
        public Factura()
        {
        }

        public int FacturaId { get; set; }
        public int VendedorId { get; set; }
        public int ProductoId { get; set; }
        public int CodigoFactura { get; set; }
        public int NumeroRUC { get; set; }
        public string FechaEmision { get; set; }
        public string FechaVencimiento { get; set; }
        public string NombreEMpresa { get; set; }
        public int importeTotal { get; set; }
    }
}