using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SisV
{
    public class Utils
    {
        public static decimal CalcularVolorizacion(string valor, int cantidad)
        {
            try
            {
                decimal Valorizacion = 0;
                Valorizacion = Math.Round((Convert.ToDecimal(valor.Replace(".", ",")) / cantidad), 1);
                return Valorizacion;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }

}