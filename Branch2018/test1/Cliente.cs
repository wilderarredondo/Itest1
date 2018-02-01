using System;

namespace test1
{
    public class Cliente
    {
        public Cliente()
        {
        }
        public int clienteId { get; set; }
        public string fullName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public int monthBirthday { get; set; }

        public override string ToString()
        {
            return $"{this.fullName} {this.lastName}";
        }
    }  
}
