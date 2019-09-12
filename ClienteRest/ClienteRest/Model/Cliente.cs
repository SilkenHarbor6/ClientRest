using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteRest.Model
{
    public class Cliente
    {
        public int id_Cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}
