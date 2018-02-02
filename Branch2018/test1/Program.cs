using System.Collections.Generic;
using System;
using Person;
using Accion;
using Object;

namespace test1
{
    public class Program
    {
        const int STOCK_MINIMUN = 1000;

        static void Main(string[] args)
        {
            List<Customer> customersList = new List<Customer>();
            List<Product> productsList = new List<Product>();
            List<Seller> sellerList = new List<Seller>();
            List<Sale> salesList = new List<Sale>();

            int optionMenu = 0;
            bool answerMenu = false;
            int numberOpcion = 0;
            while (optionMenu != 6)
            {
                while (answerMenu)
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
                    answerMenu = Int32.TryParse(Console.ReadLine(), out numberOpcion);
                }
                    
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
                                int answer = 0;                            
                                bool boolAnswer = false;
                                while (opcion != 5)
                                {
                                    while (boolAnswer)
                                    {
                                        Console.WriteLine("--------------------");
                                        Console.WriteLine("Reports Menu");
                                        Console.WriteLine("1. Total Sales");
                                        Console.WriteLine("2. Customers older to 55 years.");
                                        Console.WriteLine("3. Customers who meet years in this month.");
                                        Console.WriteLine("4. Products low stock.");
                                        Console.WriteLine("5. Return.");
                                        Console.WriteLine("Select an option");
                                        boolAnswer = Int32.TryParse(Console.ReadLine(), out answer);
                                    }   
                                                                     
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
            Console.WriteLine($"Total day sales : {salesList.Count}");

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
                        Console.WriteLine($"Customer code :  {sale.CustomerId},  Product code: {sale.ProductId}, Sales description : {sale.SaleDescription}");
                    }
                }
            }
        }

        public static void CustomersReport(List<Customer> customersList)
        {
            bool p = true;
            Console.WriteLine("Customers older to 55 years:");

            if(customersList.Count == 0)
            {
                Console.WriteLine("The are not registered customers");
            }
            else
            {
                foreach (Customer customer in customersList)
                {
                    if (customer.CustomerAge > 55)
                    {
                        p = false;
                        Console.WriteLine("--------------");
                        Console.WriteLine($"---------Customer full name : {customer.CustomerFullName  } {customer.CustomerLastName}, Age: {customer.CustomerAge}, Birhtday Month: {customer.CustomerMonthBirthday}");
                    }
                    if(p)
                    {
                        Console.WriteLine("There are not customers older to 55 yeards old");
                    }
                        
                }
            }
        }

        public static void CustomerReportAge(List<Customer> customersList)
        {
            bool flag = true;
            DateTime date = DateTime.Today;
            string monthString = date.ToString("MMMM");
            Console.WriteLine($" Customers who meet years int the month of : {monthString}");           
            int month = DateTime.Today.Month;
            
            if(customersList.Count == 0)
            {
                Console.WriteLine("The are not registered customers.");
            }
            else
            {
                foreach (Customer clients in customersList)
                {
                    if (month == clients.CustomerMonthBirthday)
                    {   
                        flag = false;   
                        Console.WriteLine("--------------");
                        Console.WriteLine($"Customer full name : {clients.CustomerFullName} {clients.CustomerLastName}, Age : {clients.CustomerAge}, Birthday Month : {clients.CustomerMonthBirthday}");                        
                    }
                    if (flag)
                    {
                        Console.WriteLine($"Any customer meet years in the month of {monthString}");           
                    }
                     
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
                    if (Products.ProductStock < STOCK_MINIMUN)
                    {
                        Console.WriteLine("--------------");
                        Console.WriteLine($"Product name : {Products.ProductName}, Price : {Products.ProductCost}, Stock : {Products.ProductStock}");                  
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
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }   
            while (!answer);
            clienteNuevo.CustomerId = number;        
            Console.WriteLine("Enter customer full name :");     
            clienteNuevo.CustomerFullName = Console.ReadLine();                                  
            Console.WriteLine("Enter  customer lastname :");
            clienteNuevo.CustomerLastName = Console.ReadLine();            
            Console.WriteLine("Enter customer email :");
            clienteNuevo.CustomerEmail = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter age :");
                answer = Int32.TryParse(Console.ReadLine(), out number); 
            }   
            while (!answer ||  number <18 || number >99);
            clienteNuevo.CustomerAge = number;
            do
            { 
                Console.WriteLine("Enter birthday  month (in numbers): ");
                answer =Int32.TryParse(Console.ReadLine(), out number);
            }
            while (!answer || (number <1 || number>12));
            clienteNuevo.CustomerMonthBirthday = number;
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
            nuevaVenta.SaleDescription = Console.ReadLine();
            nuevaVenta.SalesTotal =+ nuevaVenta.SalesTotal;
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
            vendedorNuevo.SellerFullName = Console.ReadLine();
            Console.WriteLine("Enter seller lastname :");
            vendedorNuevo.SellerLastName = Console.ReadLine();
            Console.WriteLine("Enter seller position :");
            vendedorNuevo.SellerPosition = Console.ReadLine();
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
            productoNuevo.ProductName = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter stock :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            productoNuevo.ProductStock = number;
            do
            {
                Console.WriteLine("Enter product price :");
                answer = Double.TryParse(Console.ReadLine(), out price);
            }
                while (answer == false);
            productoNuevo.ProductCost = price;
            productsList.Add(productoNuevo);
            Console.WriteLine("----------------------- Product registered successfully");
        }
    }
}

