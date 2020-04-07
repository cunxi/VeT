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
            var DataData="";
            string sError = "";

            switch (nomMaestro)
            {
                case "Color":
                    ViewBag.message = "Lista de colores proporcionados por el centro";
                    ViewBag.Nombre = "color";                                        
                    crud.cColorMascota("4", "", "", "", "", ref ds, ref sError);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            DataData = ds.ToString();
                        }
                    }

                    break;

                case "Especie":
                    ViewBag.message = "Lista de especies proporcionados por el centro";
                    ViewBag.Nombre = "especie";
                                      
                    crud.cEspecieMascota("4", "", "", "", "", ref ds, ref sError);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            DataData = ds.ToString();
                        }
                    }
                    break;

                case "Patrón":
                    ViewBag.message = "Lista de patrones proporcionados por el centro";
                    ViewBag.Nombre = "patron";

                    crud.cPatronMascota("4", "", "", "", "", ref ds, ref sError);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            DataData = ds.ToString();
                        }
                    }
                    break;

                case "Raza":
                    ViewBag.message = "Lista de razas proporcionados por el centro";
                    ViewBag.Nombre = "raza";

                    crud.cRazaMascota("4","", "", "", "", "", ref ds, ref sError);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            DataData = ds.ToString();
                        }
                    }
                    break;

                case "Producto":
                    ViewBag.message = "Lista de productos proporcionados por el centro";
                    ViewBag.Nombre = "producto";
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

        [HttpGet]
        public JsonResult Accionar(string a)
        {            
            string log_Update = "JCRetamal";
            string log_Maquina = "NT-JC";
            string resultado = "";
            string codigoResultado = "";

            DataSet ds = new DataSet();
            string Error = "";
            try
            {
                string datos;
            //Split
            string[] datosRecibidoss = a.Split('|');
            string Mantenedor = datosRecibidoss[0];
            string Accion = datosRecibidoss[1];
            string Regis = datosRecibidoss[2];

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

                crud.cColorMascota(Accion, CodigoColor.Trim(), NombreColor,log_Update, log_Maquina, ref ds, ref Error);
                {
                    if (ds.Tables.Count > 0)
                    {                           
                            resultado = ds.Tables[0].Rows[0]["Codigo"].ToString() + "|" + ds.Tables[0].Rows[0]["Resultado"].ToString();                      
                    }
                    }                   
                }
                if (Mantenedor == "ESP")
                {
                    string[] DatosEspecie= Regis.Split('~');
                    string CodigoEspecie = DatosEspecie[0];
                    string NombreEspecie = DatosEspecie[1];

                    crud.cEspecieMascota(Accion, CodigoEspecie.Trim(), NombreEspecie, log_Update, log_Maquina, ref ds, ref Error);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            resultado = ds.Tables[0].Rows[0]["Codigo"].ToString() + "|" + ds.Tables[0].Rows[0]["Resultado"].ToString();
                        }
                    }
                }
                if (Mantenedor == "PAT")
                {
                    string[] DatosPatron = Regis.Split('~');
                    string CodigoPatron = DatosPatron[0];
                    string NombrePatron = DatosPatron[1];

                    crud.cPatronMascota(Accion, CodigoPatron.Trim(), NombrePatron, log_Update, log_Maquina, ref ds, ref Error);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            resultado = ds.Tables[0].Rows[0]["Codigo"].ToString() + "|" + ds.Tables[0].Rows[0]["Resultado"].ToString();
                        }
                    }
                }
                if (Mantenedor == "RAZ")
                {
                    string[] DatosRaza = Regis.Split('~');
                    string CodigoRaza = DatosRaza[0];
                    string NombreRaza= DatosRaza[1];
                    string CodigoEspecie = DatosRaza[2];

                    crud.cRazaMascota(Accion, CodigoRaza.Trim(), NombreRaza, CodigoEspecie.Trim(), log_Update, log_Maquina, ref ds, ref Error);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            resultado = ds.Tables[0].Rows[0]["Codigo"].ToString() + "|" + ds.Tables[0].Rows[0]["Resultado"].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                resultado ="99" +"|"+ ex.Message;
                
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }       
    }
}