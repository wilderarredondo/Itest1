using System;
using System.Collections.Generic;

namespace test1
{
    class Program
    {
        const int _minimo_stock = 1000;

        static void Main(string[] args)
        {
            List<Cliente> ArrayclienteNuevo = new List<Cliente>();
            List<Producto> ArrayproductoNuevo = new List<Producto>();
            List<Vendedor> ArrayvendedorNuevo = new List<Vendedor>();
            List<Venta> ArraynuevaVenta = new List<Venta>();

            int _opcionMenu = 0;
            while (_opcionMenu != 6)
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
                _opcionMenu = int.Parse(Console.ReadLine());

                switch (_opcionMenu)
                {
                    case 1: registroVentas(ArraynuevaVenta); break;

                    case 2: registroClientes(ArrayclienteNuevo); break;

                    case 3: registroVendedores(ArrayvendedorNuevo); break;

                    case 4: registroProductos(ArrayproductoNuevo); break;

                    case 5:                
                        {
                            int _opcion = 0;
                            while (_opcion != 5)
                            {
                                Console.WriteLine("--------------------");
                                Console.WriteLine("Menu de Reportes");
                                Console.WriteLine("1. Total de Ventas");
                                Console.WriteLine("2. Clientes mayores a 55 años de edad");
                                Console.WriteLine("3. Clientes que cumplen años en el mes");
                                Console.WriteLine("4. Productos con stock bajo.");
                                Console.WriteLine("5. Regresar.");
                                Console.WriteLine("Seleccione una opcion");
                                _opcion = int.Parse(Console.ReadLine());                               
                                switch (_opcion)
                                {
                                    case 1: reporteVentas(ArraynuevaVenta); break;
                                    case 2: reporteClientes(ArrayclienteNuevo); break;
                                    case 3: reporteClientesEdad(ArrayclienteNuevo); break;
                                    case 4: reporteProductos(ArrayproductoNuevo); break;
                                    case 5:; break;
                                }
                            }
                        }
                        break;
                }
            }
            Console.WriteLine("Gracias por su visita");
        }

        public static void reporteVentas(List<Venta> ArraynuevaVenta)
        {
            bool _param= true;
            Console.WriteLine("Total de Ventas del dia :"+ ArraynuevaVenta.Count);
            if(ArraynuevaVenta.Count==0){
                Console.WriteLine("NO HAY VENTAS REGISTRADAS");
                _param = false; 
            }
            else
                foreach (Venta venta in ArraynuevaVenta)
                {
                        if (_param)
                        {                            
                            Console.WriteLine("--------------");
                            Console.WriteLine("-Codigo del cliente :" + $"{venta.ClienteId},  Codigo del producto: {venta.ProductoId}, Descripcion de la venta : {venta.descripcion}");                               
                        }
                }
        }

        public static void reporteClientes(List<Cliente> ArrayclienteNuevo)
        {
            bool _param= true;
            Console.WriteLine("Clientes mayores a 55 años:");

            if(ArrayclienteNuevo.Count==0){
                Console.WriteLine("NO HAY CLIENTES REGISTRADOS");
            }
            else
                foreach (Cliente clients in ArrayclienteNuevo)
                {
                        if (clients.Edad > 55)
                        {
                            _param = false;
                            Console.WriteLine("--------------");
                            Console.WriteLine("---------" + $"{clients.Nombre} {clients.Apellido}, edad: {clients.Edad}, mes cumpleaños : {clients.MesCumpleanos}");
                        }
                        if(_param)
                            Console.WriteLine("NO HAY CLIENTES MAYORES A 55 AñOS");                
                }
        }
        public static void reporteClientesEdad(List<Cliente> ArrayclienteNuevo)
        {
            bool _flag = true;
            DateTime date = DateTime.Today;
            string mes_cadena = date.ToString("MMMM");
            Console.WriteLine("Clientes que cumplen años en el mes :"+mes_cadena);           
            int _mes = DateTime.Today.Month;
            if(ArrayclienteNuevo.Count==0){
                Console.WriteLine("NO HAY CLIENTES REGISTRADOS");
            }
            else
                foreach (Cliente clients in ArrayclienteNuevo)
                {
                        if (_mes == clients.MesCumpleanos)
                        {   
                            _flag=false;
                            Console.WriteLine("--------------");
                            Console.WriteLine("Nombres del cliente :" + $"{clients.Nombre} {clients.Apellido}, edad : {clients.Edad}, Mes cumpleaños :{clients.MesCumpleanos}");                        
                        }
                        if(_flag)
                            Console.WriteLine("NINGUN CLIENTE CUMPLE AñOS EN EL MES DE "+mes_cadena);                
                }
        }
        public static void reporteProductos(List<Producto> ArrayproductoNuevo)
        {

            Console.WriteLine("Productos con bajo stock");
            if(ArrayproductoNuevo.Count==0){
                Console.WriteLine("NO HAY PRODUCTOS REGISTRADOS");
            }
            else
                foreach (Producto Products in ArrayproductoNuevo)
                {              
                    if (Products.stock < _minimo_stock)
                    {
                        Console.WriteLine("--------------");
                        Console.WriteLine("Nombre del Producto :" + $"{Products.NombreProducto}, Precio : {Products.Precio}, stock : {Products.stock}");                  
                    }
                    else
                        Console.WriteLine("NO HAY PRODUCTOS CON STOCK MENOR AL PROMEDIO DE STOCKS");
                }
        }

        public static void registroClientes(List<Cliente> ArrayclienteNuevo)
        {
            int _vari;
            Cliente clienteNuevo = new Cliente();
            Console.WriteLine("--------------------");
            Console.WriteLine("Registro de Clientes");
            Console.WriteLine("--------------------");
            Console.WriteLine("Ingrese codigo(dni) del cliente :");
            clienteNuevo.ClienteId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nombres del cliente :");
            clienteNuevo.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellidos del cliente :");
            clienteNuevo.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese correo del cliente :");
            clienteNuevo.Correo = Console.ReadLine();
            Console.WriteLine("Ingrese su edad :");
            clienteNuevo.Edad = int.Parse(Console.ReadLine());                        
            do{ Console.WriteLine("Ingrese mes de cumpleanos (numeros):");
                _vari =int.Parse(Console.ReadLine());}while(_vari <1 && _vari>12);
            clienteNuevo.MesCumpleanos = _vari;
            ArrayclienteNuevo.Add(clienteNuevo);
            Console.WriteLine("----------------------- Cliente registrado exitosamente");
        }
        public static void registroVentas(List<Venta> ArraynuevaVenta)
        {

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
            nuevaVenta.totalVentas=+nuevaVenta.totalVentas;
            ArraynuevaVenta.Add(nuevaVenta);
            Console.WriteLine("----------------------- Venta registrada exitosamente");
        }
        public static void registroVendedores(List<Vendedor> ArrayvendedorNuevo)
        {

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
            Console.WriteLine("----------------------- Vendedor registrado exitosamente");
        }


        public static void registroProductos(List<Producto> ArrayproductoNuevo)
        {

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
            Console.WriteLine("----------------------- Producto registrado exitosamente");
        }
    }
}

