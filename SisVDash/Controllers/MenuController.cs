using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cnx.Data;

namespace SisVDash.Controllers
{
    public class MenuController : Controller
    {

        Models.Crud crud = new Models.Crud();
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Maestro(string nomMaestro)
        {
            ViewBag.Title = "Mantenedor de " + nomMaestro;
            DataSet ds = new DataSet();


            switch (nomMaestro)
            {
                case "Color":
                    ViewBag.message = "Lista de colores proporcionados por el centro";
                    ViewBag.Nombre = "color";
                    var DataColor = "";
                    string Error = "";
                    crud.cColorMascota("4", "", "", "", "", ref ds, ref Error);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            DataColor = ds.ToString();
                        }
                    }

                    break;

                case "Mascota":
                    ViewBag.message = "Lista de mascotas proporcionados por el centro";
                    ViewBag.Nombre = "mascota";
                    break;


                case "Servicio":
                    ViewBag.message = "Lista de servicios proporcionados por el centro";
                    ViewBag.Nombre = "servicio";
                    break;

                case "Producto":
                    ViewBag.message = "Lista de productos proporcionados por el centro";
                    ViewBag.Nombre = "producto";
                    break;


                case "Especie":
                    ViewBag.message = "Lista de especies proporcionados por el centro";
                    ViewBag.Nombre = "especie";
                    break;

                case "Raza":
                    ViewBag.message = "Lista de razas proporcionados por el centro";
                    ViewBag.Nombre = "raza";
                    break;



                case "Patrón":
                    ViewBag.message = "Lista de patrones proporcionados por el centro";
                    ViewBag.Nombre = "patrón";
                    break;

                default:
                    break;
            }
            return View(ds);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Usuario, string Contrasena)
        {
            string Codigo = "";
            string Mensaje = "Usuario/Contraseña Incorrecta";
            DataSet ds = new DataSet();
            string Error = "";
            crud.cIngresaUsuario(Usuario, Contrasena, ref ds, ref Error);

            if (ds.Tables.Count > 0)
            {
                Codigo = ds.Tables[0].Rows[0]["Codigo"].ToString();
                Mensaje = ds.Tables[0].Rows[0]["Mensaje"].ToString();

                if (Codigo == "0")
                {
                    return RedirectToAction("Inicio", "Menu");
                    Session["Log_Update"] = "JCRetamal";
                    Session["Log_Maquina"] = "NT-JC";

                }
                else
                {
                    ViewBag.Message = Mensaje;
                    return View();
                }
            }
            else
            {
                ViewBag.Message = Mensaje;
                return View();
            }

        }

        public ActionResult Accionar(string a)
        {
            string R = "";
            string Log_Update = "JCRetamal";
            string Log_Maquina = "NT-JC";
            DataSet ds = new DataSet();
            string Error = "";
            //Split
            string[] datos = a.Split('|');
            string Mantenedor = datos[0];
            string Accion = datos[1];
            string Regis = datos[2];

            switch (Accion)
            {
                case "I":
                    Accion = "1";                
                break;
                case "D":
                    Accion = "3";
                break;
                case "U":
                    Accion = "2";
                break;
            }


            if (Mantenedor == "COL")
            {
                string[] DatosColor = Regis.Split('~');
                string CodigoColor = DatosColor[0];
                string NombreColor = DatosColor[1];

                crud.cColorMascota(Accion, CodigoColor, NombreColor,Log_Update, Log_Maquina, ref ds, ref Error);
                {
                    if (ds.Tables.Count > 0)
                    {                       
                       R = ds.Tables[0].Rows[0]["R"].ToString();
                    }
                   
                   
                }
            }
            return Json(R, JsonRequestBehavior.AllowGet);

        }


    }
}