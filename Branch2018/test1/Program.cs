using System;
using System.Collections.Generic;

namespace test1
{
    public class Program
    {
        const int minimo_stock = 1000;
        static void Main(string[] args)
        {
            List<Cliente> arrayclienteNuevo = new List<Cliente>();
            List<Producto> arrayproductoNuevo = new List<Producto>();
            List<Vendedor> arrayvendedorNuevo = new List<Vendedor>();
            List<Venta>    arraynuevaVenta = new List<Venta>();

            int optionMenu = 0;
            bool answerMenu ;
            int numberOpcion;
            while (optionMenu != 6)
            {
                do
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Menu de Facturacion");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("1. Registro de Ventas");
                    Console.WriteLine("2. Registro de Clientes");
                    Console.WriteLine("3. Registro de vendedores");
                    Console.WriteLine("4. Registro de Productos");
                    Console.WriteLine("5. Reportes");
                    Console.WriteLine("6. Salir");
                    Console.WriteLine("Seleccione una opcion");
                    answerMenu= Int32.TryParse(Console.ReadLine(), out numberOpcion);
                }   while (answerMenu==false);
                optionMenu = numberOpcion;
                switch (optionMenu)
                {
                    case 1: RegistroVentas(arraynuevaVenta); break;

                    case 2: RegistroClientes(arrayclienteNuevo); break;

                    case 3: RegistroVendedores(arrayvendedorNuevo); break;

                    case 4: RegistroProductos(arrayproductoNuevo); break;

                    case 5:                
                        {
                            int opcion = 0;
                            int answer = 0;
                            bool boolAnswer = true;
                            while (opcion != 5)
                            {
                                do
                                {
                                    Console.WriteLine("--------------------");
                                    Console.WriteLine("Menu de Reportes");
                                    Console.WriteLine("1. Total de Ventas");
                                    Console.WriteLine("2. Clientes mayores a 55 años de edad");
                                    Console.WriteLine("3. Clientes que cumplen años en el mes");
                                    Console.WriteLine("4. Productos con stock bajo.");
                                    Console.WriteLine("5. Regresar.");
                                    Console.WriteLine("Seleccione una opcion");
                                    boolAnswer = Int32.TryParse(Console.ReadLine(),out answer);
                                }   while (boolAnswer == false);                              
                                opcion = answer;
                                switch (opcion)
                                {
                                    case 1: ReporteVentas(arraynuevaVenta);break; 
                                            
                                    case 2: ReporteClientes(arrayclienteNuevo);break;
                                            
                                    case 3: ReporteClientesEdad(arrayclienteNuevo);break; 
                                            
                                    case 4: ReporteProductos(arrayproductoNuevo);break; 
                                            
                                    case 5: break;
                                }
                            }
                        }
                        break;
                }
            }
            Console.WriteLine("Gracias por su visita");
        }
        public static void ReporteVentas(List<Venta> arraynuevaVenta)
        {
            bool p= true;
            Console.WriteLine("Total de Ventas del dia :"+ arraynuevaVenta.Count);
            if(arraynuevaVenta.Count==0){
                Console.WriteLine("NO HAY VENTAS REGISTRADAS");
                p = false; 
            }
            else
                foreach (Venta venta in arraynuevaVenta)
                {
                        if (p)
                        {                            
                            Console.WriteLine("--------------");
                            Console.WriteLine("-Codigo del cliente :" + $"{venta.clienteId},  Codigo del producto: {venta.productoId}, Descripcion de la venta : {venta.description}");                               
                        }
                }
        }
        public static void ReporteClientes(List<Cliente> arrayclienteNuevo)
        {
            bool p= true;
            Console.WriteLine("Clientes mayores a 55 años:");

            if(arrayclienteNuevo.Count==0){
                Console.WriteLine("NO HAY CLIENTES REGISTRADOS");
            }
            else
                foreach (Cliente clients in arrayclienteNuevo)
                {
                        if (clients.age > 55)
                        {
                            p = false;
                            Console.WriteLine("--------------");
                            Console.WriteLine("---------" + $"{clients.fullName  } {clients.lastName}, edad: {clients.age}, mes cumpleaños : {clients.monthBirthday}");
                        }
                        if(p)
                            Console.WriteLine("NO HAY CLIENTES MAYORES A 55 AñOS");                
                }
        }
        public static void ReporteClientesEdad(List<Cliente> arrayclienteNuevo)
        {
            bool flag = true;
            DateTime date = DateTime.Today;
            string monthString = date.ToString("MMMM");
            Console.WriteLine("Clientes que cumplen años en el mes :"+monthString);           
            int month = DateTime.Today.Month;
            if(arrayclienteNuevo.Count==0){
                Console.WriteLine("NO HAY CLIENTES REGISTRADOS");
            }
            else
                foreach (Cliente clients in arrayclienteNuevo)
                {
                        if (month == clients.monthBirthday)
                        {   
                            flag = false;
                            Console.WriteLine("--------------");
                            Console.WriteLine("Nombres del cliente :" + $"{clients.fullName} {clients.lastName}, edad : {clients.age}, Mes cumpleaños :{clients.monthBirthday}");                        
                        }
                        if (flag)
                            Console.WriteLine("NINGUN CLIENTE CUMPLE AñOS EN EL MES DE " + monthString);                
                }
        }
        public static void ReporteProductos(List<Producto> arrayproductoNuevo)
        {

            Console.WriteLine("Productos con bajo stock");
            if(arrayproductoNuevo.Count==0){
                Console.WriteLine("NO HAY PRODUCTOS REGISTRADOS");
            }
            else
                foreach (Producto Products in arrayproductoNuevo)
                {              
                    if (Products.stock < _minimo_stock)
                    {
                        Console.WriteLine("--------------");
                        Console.WriteLine("Nombre del Producto :" + $"{Products.nameProduct}, Precio : {Products.cost}, stock : {Products.stock}");                  
                    }
                    else
                        Console.WriteLine("NO HAY PRODUCTOS CON STOCK MENOR AL PROMEDIO DE STOCKS");
                }
        }
        public static void RegistroClientes(List<Cliente> arrayclienteNuevo)
        {
            int number;
            bool answer;
            Cliente clienteNuevo = new Cliente();
            Console.WriteLine("--------------------");
            Console.WriteLine("Registro de Clientes");
            Console.WriteLine("--------------------");
            do 
            {
                Console.WriteLine("Ingrese codigo(dni) del cliente :");
                answer = Int32.TryParse(Console.ReadLine(),out number);
            }   
                while (answer==false);
            clienteNuevo.clienteId = number;        
            Console.WriteLine("Ingrese nombres del cliente :");     
            clienteNuevo.fullName = Console.ReadLine();                                  
            Console.WriteLine("Ingrese apellidos del cliente :");
            clienteNuevo.lastName = Console.ReadLine();            
            Console.WriteLine("Ingrese correo del cliente :");
            clienteNuevo.email = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingrese su edad :");
                answer = Int32.TryParse(Console.ReadLine(), out number); 
            }   
                while (answer==false ||  number <18 || number >99);
            clienteNuevo.age = number;
            do
            { 
                Console.WriteLine("Ingrese mes de cumpleanos (numeros):");
                answer =Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer==false || (number <1 || number>12));
            clienteNuevo.monthBirthday = number;
            arrayclienteNuevo.Add(clienteNuevo);
            Console.WriteLine("----------------------- Cliente registrado exitosamente");
        }
        public static void RegistroVentas(List<Venta> arraynuevaVenta)
        {
            int number;
            bool answer;
            Venta nuevaVenta = new Venta();
            Console.WriteLine("--------------------");
            Console.WriteLine("Registro de Ventas");
            Console.WriteLine("--------------------");
            do
            {
                Console.WriteLine("Ingrese codigo de la factura :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while(answer == false);
            nuevaVenta.facturaId = number;
            do
            {
                Console.WriteLine("Ingrese codigo del producto :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while(answer == false);
            nuevaVenta.productoId = number;
            do
            {
                Console.WriteLine("Ingrese codigo del vendedor :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while(answer == false);
            nuevaVenta.vendedorId = number;
            do
            {
                Console.WriteLine("Ingrese codigo del cliente :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            nuevaVenta.clienteId = number;
            Console.WriteLine("Ingrese descripcion de la venta :");
            nuevaVenta.description = Console.ReadLine();
            nuevaVenta.totalVentas=+nuevaVenta.totalVentas;
            arraynuevaVenta.Add(nuevaVenta);
            Console.WriteLine("----------------------- Venta registrada exitosamente");
        }
        public static void RegistroVendedores(List<Vendedor> ArrayvendedorNuevo)
        {
            int number;
            bool answer;
            Vendedor vendedorNuevo = new Vendedor();
            Console.WriteLine("--------------------");
            Console.WriteLine("Registro de Vendedores");
            Console.WriteLine("--------------------");
            do
            {
                Console.WriteLine("Ingrese codigo :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            vendedorNuevo.vendedorId =   number;
            Console.WriteLine("Ingrese nombres :");
            vendedorNuevo.fullName = Console.ReadLine();
            Console.WriteLine("Ingrese apellidos :");
            vendedorNuevo.lastName = Console.ReadLine();
            Console.WriteLine("Ingrese correo :");
            vendedorNuevo.position = Console.ReadLine();
            ArrayvendedorNuevo.Add(vendedorNuevo);
            Console.WriteLine("----------------------- Vendedor registrado exitosamente");
        }
        public static void RegistroProductos(List<Producto> ArrayproductoNuevo)
        {
            int number;
            double price;
            bool answer;
            Producto productoNuevo = new Producto();
            Console.WriteLine("--------------------");
            Console.WriteLine("Registro de Productos");
            Console.WriteLine("--------------------");
            do
            {
                Console.WriteLine("Ingrese codigo :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }    
                while (answer == false);
            productoNuevo.productoId = number;
            
            Console.WriteLine("Ingrese nombre :");
            productoNuevo.nameProduct = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingrese stock :");
                answer = Int32.TryParse(Console.ReadLine(), out number);
            }
                while (answer == false);
            productoNuevo.stock = number;

            do
            {
                Console.WriteLine("Ingrese precio :");
                answer = Double.TryParse(Console.ReadLine(), out price);
            }
                while (answer == false);
            productoNuevo.cost = price;
            ArrayproductoNuevo.Add(productoNuevo);
            Console.WriteLine("----------------------- Producto registrado exitosamente");
        }
    }
}

