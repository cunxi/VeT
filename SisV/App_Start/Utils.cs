using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SisV
{
    public class Utils
    {
        public const string SESION_USUARIO_MODEL = "usuario-model";

        public static void GuardarUsuarioSesion(Models.Usuario usuario)
        {
            HttpContext context = HttpContext.Current;
            context.Session.Timeout = 120;
            context.Server.ScriptTimeout = 120;
            context.Session[SESION_USUARIO_MODEL] = usuario;
        }

        public static Models.Usuario ObtenerUsuarioSesion()
        {
            HttpContext context = HttpContext.Current;
            return (Models.Usuario)context.Session[SESION_USUARIO_MODEL];
        }

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