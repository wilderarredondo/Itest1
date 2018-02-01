using System;
using System.Collections.Generic;

namespace test1
{
    public class Program
    {
        const int MINIMO_STOCK = 1000;

        static void Main(string[] args)
        {
            List<Customer> customersList = new List<Customer>();
            List<Product> productsList = new List<Product>();
            List<Seller> sellerList = new List<Seller>();
            List<Sale> salesList = new List<Sale>();

            int optionMenu = 0;
            bool answerMenu;
            int numberOpcion;
            while (optionMenu != 6)
            {
                do
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Billing Menu");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("1. Sales Registration");
                    Console.WriteLine("2. Customers Registration");
                    Console.WriteLine("3. Seller Registration");
                    Console.WriteLine("4. Products Registration");
                    Console.WriteLine("5. Reports");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("Select an option");
                    answerMenu= Int32.TryParse(Console.ReadLine(), out numberOpcion);
                }   
                    while (answerMenu == false);
                optionMenu = numberOpcion;
                switch (optionMenu)
                {
                    case 1: SalesRegistration(salesList); 
                            break;

                    case 2: CustomerRegistration(customersList); 
                            break;

                    case 3: SellerRegistration(sellerList); 
                            break;

                    case 4: ProductRegistration(productsList); 
                            break;

                    case 5:                
                            {
                                int opcion = 0;
                                int answer;                            
                                bool boolAnswer = true;
                                while (opcion != 5)
                                {
                                    do
                                    {
                                        Console.WriteLine("--------------------");
                                        Console.WriteLine("Reports Menu");
                                        Console.WriteLine("1. Total Sales");
                                        Console.WriteLine("2. Customers older to 55 years.");
                                        Console.WriteLine("3. Customers who meet years in this month.");
                                        Console.WriteLine("4. Products low stock.");
                                        Console.WriteLine("5. Return.");
                                        Console.WriteLine("Select an option");
                                        boolAnswer = Int32.TryParse(Console.ReadLine(),out answer);
                                    }   
                                        while (boolAnswer == false);                              
                                    opcion = answer;
                                    switch (opcion)
                                    {
                                        case 1: SalesReport(salesList);
                                                break; 
                                                
                                        case 2: CustomersReport(customersList);
                                                break;
                                                
                                        case 3: CustomerReportAge(customersList);
                                                break; 
                                                
                                        case 4: ProductsReport(productsList);
                                                break; 
                                                
                                        case 5: break;
                                    }
                                }
                            }
                            break;
                }
            }
            Console.WriteLine("Thank for your visit.");
        }

        public static void SalesReport(List<Sale> salesList)
        {
            bool p = true;
            Console.WriteLine("Total day sales :"+ salesList.Count);
            if(salesList.Count == 0)
            {
                Console.WriteLine("There are not registered sales.");
                p = false; 
            }
            else
                {
                    foreach (Sale sale in salesList)
                    {
                            if (p)
                            {                            
                                Console.WriteLine("--------------");
                                Console.WriteLine("Customer code :" + $"{sale.CustomerId},  Product code: {sale.ProductId}, Sales description : {sale.Description}");                               
                            }
                    }
                }
        }

        public static void CustomersReport(List<Customer> clustomersList)
        {
            bool p = true;
            Console.WriteLine("Customers older to 55 years:");

            if(clustomersList.Count == 0)
            {
                Console.WriteLine("The are not registered customers");
            }
            else
                {
                    foreach (Customer customer in clustomersList)
                    {
                            if (customer.Age > 55)
                            {
                                p = false;
                                Console.WriteLine("--------------");
                                Console.WriteLine("---------Customer full name :" + $"{customer.FullName  } {customer.LastName}, Age: {customer.Age}, Birhtday Month: {customer.MonthBirthday}");
                            }
                            if(p)
                                Console.WriteLine("There are not customers older to 55 yeards old");                
                    }
                }
        }

        public static void CustomerReportAge(List<Customer> clustomersList)
        {
            bool flag = true;
            DateTime date = DateTime.Today;
            string monthString = date.ToString("MMMM");
            Console.WriteLine($" Customers who meet years int the month of : {monthString}");           
            int month = DateTime.Today.Month;
            if(clustomersList.Count == 0)
            {
                Console.WriteLine("The are not registered customers.");
            }
            else
                {
                    foreach (Customer clients in clustomersList)
                    {
                            if (month == clients.MonthBirthday)
                            {   
                                flag = false;
                                Console.WriteLine("--------------");
                                Console.WriteLine("Customer full name :" + $"{clients.FullName} {clients.LastName}, Age : {clients.Age}, Birthday Month : {clients.MonthBirthday}");                        
                            }
                            if (flag)
                                Console.WriteLine($"Any customer meet years in the month of {monthString}");           
                    }
                }
        }

        public static void ProductsReport(List<Product> productsList)
        {

            Console.WriteLine("Products with stock is minimum");
            if(productsList.Count == 0)
            {
                Console.WriteLine("There are not registered products.");
            }
            else
                {
                    foreach (Product Products in productsList)
                    {              
                        if (Products.Stock < MINIMO_STOCK)
                        {
                            Console.WriteLine("--------------");
                            Console.WriteLine("Product name : " + $"{Products.NameProduct}, Price : {Products.Cost}, Stock : {Products.Stock}");                  
                        }
                        else
                            Console.WriteLine("The are not products with stock less at all them");
                    }
                }
        }

        public static void CustomerRegistration(List<Customer> customersList)
        {
            int number;
            bool answer;
            Customer clienteNuevo = new Customer();
            Console.WriteLine("---------------------");
            Console.WriteLine("Customer Registration");
            Console.WriteLine("---------------------");
            do 
            {
                Console.WriteLine("Enter customer DNI :");
                answer = Int32.TryParse(Console.ReadLine(),out number);
            }   
                while (answer == false);
            clienteNuevo.CustomerId = number;        
            Console.WriteLine("Enter customer full name :");     
            clienteNuevo.FullName = Console.ReadLine();                                  
            Console.WriteLine("Enter  customer lastname :");
            clienteNuevo.LastName = Console.ReadLine();            
            Console.WriteLine("Enter customer email :");
            clienteNuevo.Email = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter age :");
                answer = Int32.TryParse(Console.ReadLine(), out number); 
            }   
                while (answer == false ||  number <18 || number >99);
            clienteNuevo.Age = number;
            do
            { 
                Console.WriteLine("Enter birthday  month (in numbers): ");
                answer =Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false || (number <1 || number>12));
            clienteNuevo.MonthBirthday = number;
            customersList.Add(clienteNuevo);
            Console.WriteLine("----------------------- Customer registered successfully");
        }

        public static void SalesRegistration(List<Sale> salesList)
        {
            int number;
            bool answer;
            Sale nuevaVenta = new Sale();
            Console.WriteLine("--------------------");
            Console.WriteLine("Sales Registration");
            Console.WriteLine("--------------------");
            do
            {
                Console.WriteLine("Enter bill code :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            nuevaVenta.BillId = number;
            do
            {
                Console.WriteLine("Enter product code :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            nuevaVenta.ProductId = number;
            do
            {
                Console.WriteLine("Enter seller code :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            nuevaVenta.SellerId = number;
            do
            {
                Console.WriteLine("Enter customer code :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            nuevaVenta.CustomerId = number;
            Console.WriteLine("Enter sales description :");
            nuevaVenta.Description = Console.ReadLine();
            nuevaVenta.TotalSales =+ nuevaVenta.TotalSales;
            salesList.Add(nuevaVenta);
            Console.WriteLine("----------------------- Sales registered successfully");
        }

        public static void SellerRegistration(List<Seller> sellerList)
        {
            int number;
            bool answer;
            Seller vendedorNuevo = new Seller();
            Console.WriteLine("--------------------");
            Console.WriteLine("Seller Registration");
            Console.WriteLine("--------------------");
            do
            {
                Console.WriteLine("Enter seller code :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            vendedorNuevo.SellerId =   number;
            Console.WriteLine("Enter seller full name :");
            vendedorNuevo.FullName = Console.ReadLine();
            Console.WriteLine("Enter seller lastname :");
            vendedorNuevo.LastName = Console.ReadLine();
            Console.WriteLine("Enter seller email :");
            vendedorNuevo.Position = Console.ReadLine();
            sellerList.Add(vendedorNuevo);
            Console.WriteLine("----------------------- Seller registered successfully");
        }

        public static void ProductRegistration(List<Product> productsList)
        {
            int number;
            double price;
            bool answer;
            Product productoNuevo = new Product();
            Console.WriteLine("--------------------");
            Console.WriteLine("Product Registration");
            Console.WriteLine("--------------------");
            do
            {
                Console.WriteLine("Enter product code :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }    
                while (answer == false);
            productoNuevo.ProductId = number;
            Console.WriteLine("Enter product name :");
            productoNuevo.NameProduct = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter stock :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            productoNuevo.Stock = number;
            do
            {
                Console.WriteLine("Enter product price :");
                answer = Double.TryParse(Console.ReadLine(), out price);
            }
                while (answer == false);
            productoNuevo.Cost = price;
            productsList.Add(productoNuevo);
            Console.WriteLine("----------------------- Product registered successfully");
        }
    }
}

