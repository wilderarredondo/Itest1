using System;

namespace test1
{
    public class Sale
    {
        public Sale()
        {
        }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public int SellerId { get; set; }

        public int BillId { get; set; }

        public string Description { get; set; }

        public int CustomerId { get; set; }
        
        public int TotalSales { get; set; }
    }
}