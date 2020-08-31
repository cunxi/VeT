using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisV.Models
{
    public class Horario_Centro
    {
        public DateTime Fecha { get; set; }
        public List<string> horas { get; set; }
    }
}