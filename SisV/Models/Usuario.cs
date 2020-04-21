using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisV.Models
{
    public class Usuario
    {
        public string ID { get; set; }
        public string Identificador { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Imagen { get; set; }
        public int Level {get;set;}
        public string log_ID_Login { get; set; }
}
}