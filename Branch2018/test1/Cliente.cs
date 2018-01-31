using System;

namespace test1
{
    public class Cliente
    {
        public Cliente()
        {
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public int MesCumpleanos { get; set; }
        public override string ToString()
        {
            return $"{this.Nombre} {this.Apellido}";
        }

    }
        
}
