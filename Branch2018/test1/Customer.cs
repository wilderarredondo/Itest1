namespace Person
{
    public class Customer
    {
        public Customer()
        {
        }

        public int CustomerId { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerEmail { get; set; }

        public int CustomerAge { get; set; }

        public int CustomerMonthBirthday { get; set; }

        public override string ToString()
        {
            return $"{this.CustomerFullName} {this.CustomerLastName}";
        }
    }  
}
