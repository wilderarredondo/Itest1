using System;

namespace dotnetcore
{
    public class Cliente
    {
         public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string MesCumpleanos { get; set; }
        public override string ToString()
        {
            return $"{this.Nombre} {this.Apellido}";
        }


        public void registroClientes(){

            
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
}
