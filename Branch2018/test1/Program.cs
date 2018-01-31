using System;
using System.Collections.Generic;

namespace test1
{
    class Program
    {
        //public List<Venta> ArraynuevaVenta = new List<Venta>();
        //public List<Cliente> ArrayclienteNuevo = new List<Cliente>();
        static void Main(string[] args)
        {
            
             int _OpcionMenu = 0;            
            while(_OpcionMenu!=6){
                Console.WriteLine("--------------------");
                Console.WriteLine("Menu de Facturacion");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Registro de Ventas");
                Console.WriteLine("2. Registro de Clientes");
                Console.WriteLine("3. Registro de vendedores");
                Console.WriteLine("4. Registro de Productos");
                Console.WriteLine("5. Reportes");
                Console.WriteLine("6. Reportes");
                Console.WriteLine("Seleccione una opcion");
                _OpcionMenu = int.Parse(Console.ReadLine());
                        
                switch(_OpcionMenu){                     
                    case 1: registroVentas();break;
                    case 2: registroClientes();break;                
                    case 3:registroVendedores();break;
                    case 4:registroProductos();break;
                    case 5:menuReporte();break;
                    default : Console.WriteLine("Gracias por su visita");break;
                }
            }
        }

        public static void menuReporte(){
            Console.WriteLine("--------------------");
            Console.WriteLine("Menu de Reportes");
            Console.WriteLine("1. Total de Ventas");
            Console.WriteLine("2. Clientes mayores a 55 años de edad");
            Console.WriteLine("3. Clientes que cumplen años en el mes");
            Console.WriteLine("4. Productos con stock bajo.");
        }

        public static void reporteVentas(){

            Console.WriteLine("Total de Ventas del dia :");

        }

        public static void reporteClientes(){

            Console.WriteLine("Clientes mayores a 55 años:");
            //foreach(Cliente client in ArrayclienteNuevo)

        }
        public static void reporteClientesEdad(){

            Console.WriteLine("Total de Ventas del dia :");

        }
        public static void reporteProductos(){

            Console.WriteLine("Productos con bajo stock");
            

        }

        public static void registroClientes(){   
            
            List<Cliente> ArrayclienteNuevo = new List<Cliente>(); 
            Cliente clienteNuevo = new Cliente();
            Console.WriteLine("--------------------");
            Console.WriteLine("Registro de Clientes");
            Console.WriteLine("--------------------");
            Console.WriteLine("Ingrese codigo del cliente :");
            clienteNuevo.ClienteId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nombres del cliente :");
            clienteNuevo.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellidos del cliente :");
            clienteNuevo.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese correo del cliente :");
            clienteNuevo.Correo = Console.ReadLine();
            Console.WriteLine("Ingrese su edad :");
            clienteNuevo.Edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese mes de cumpleanos (letras):");
            clienteNuevo.MesCumpleanos = Console.ReadLine();
            ArrayclienteNuevo.Add(clienteNuevo);
            Console.WriteLine("Cliente registrado exitosamente");
    }
        public static void registroVentas(){
            
            List<Venta> ArraynuevaVenta = new List<Venta>();
            Venta nuevaVenta = new Venta();
            Console.WriteLine("--------------------");
            Console.WriteLine("Registro de Ventas");
            Console.WriteLine("--------------------");
            Console.WriteLine("Ingrese codigo de la factura :");
            nuevaVenta.FacturaId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese codigo del producto :");
            nuevaVenta.ProductoId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese codigo del vendedor :");
            nuevaVenta.VendedorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese codigo del cliente :");
            nuevaVenta.ClienteId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese descripcion de la venta :");
            nuevaVenta.descripcion = Console.ReadLine();
            ArraynuevaVenta.Add(nuevaVenta);
            Console.WriteLine("Cliente registrado exitosamente");
        
        
        }
        public static void registroVendedores(){

            List<Vendedor> ArrayvendedorNuevo = new List<Vendedor>();
            Vendedor vendedorNuevo = new Vendedor();
            Console.WriteLine("--------------------");
            Console.WriteLine("Registro de Vendedores");
            Console.WriteLine("--------------------");
            Console.WriteLine("Ingrese codigo :");
            vendedorNuevo.VendedorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nombres :");
            vendedorNuevo.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellidos :");
            vendedorNuevo.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese correo :");
            vendedorNuevo.Cargo = Console.ReadLine();   
            ArrayvendedorNuevo.Add(vendedorNuevo);         
            Console.WriteLine("Vendedor registrado exitosamente");
        }


        public static void registroProductos(){
            List<Producto> ArrayproductoNuevo = new List<Producto>();
            Producto productoNuevo = new Producto();
            Console.WriteLine("--------------------");
            Console.WriteLine("Registro de Productos");
            Console.WriteLine("--------------------");
            Console.WriteLine("Ingrese codigo :");
            productoNuevo.ProductoId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nombre :");
            productoNuevo.NombreProducto = Console.ReadLine();
            Console.WriteLine("Ingrese stock :");
            productoNuevo.stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese precio :");
            productoNuevo.Precio = int.Parse(Console.ReadLine());
            ArrayproductoNuevo.Add(productoNuevo);
            Console.WriteLine("Producto registrado exitosamente");
        }
    }

     public class Producto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public double Precio { get; set; }
        public string DescripcionProducto { get; set; }
        public int stock { get; set; }
        const int minimo_stock = 1000;
    }

     public class Vendedor
    {
        public int VendedorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }

    }

    public class Venta { 

        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int VendedorId { get; set; }
        public int FacturaId { get; set; }
        public string descripcion { get; set; }
        public int ClienteId { get; set; }
    }
     public class Factura
    {
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
        
