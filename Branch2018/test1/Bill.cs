namespace Object
{
    public class Bill
    {
        public Bill()
        {
        }

        public int BillId { get; set; }

        public int SellerId { get; set; }

        public int ProductId { get; set; }

        public int CodeBill { get; set; }

        public int NumberRUC { get; set; }

        public string DateEmision { get; set; }

        public string DateExpiration { get; set; }

        public string NameCompany { get; set; }
        
        public int AmountTotal { get; set; }
    }
}