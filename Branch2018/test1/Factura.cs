
using System;

namespace test1
{
  public class Factura
    {
        public Factura()
        {
        }
        public int facturaId { get; set; }
        public int vendedorId { get; set; }
        public int productoId { get; set; }
        public int codeBill { get; set; }
        public int numberRUC { get; set; }
        public string dateEmision { get; set; }
        public string dateExpiration { get; set; }
        public string nameCompany { get; set; }
        public int amountTotal { get; set; }
    }
}