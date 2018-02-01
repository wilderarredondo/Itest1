using System;

namespace test1
{
    public class Customer
    {
        public Customer()
        {
        }

        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public int MonthBirthday { get; set; }

        public override string ToString()
        {
            return $"{this.FullName} {this.LastName}";
        }
    }  
}
