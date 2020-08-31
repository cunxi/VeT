using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cnx.Data;
using SisVDash.Models;
using Newtonsoft.Json;
using System.IO;

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
                    DataSet dsEspecies = new DataSet();
                    crud.cRazaMascota("4","", "", "", "", "", ref ds, ref sError);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            DataData = ds.ToString();                       
                        }
                    }

                    crud.cEspecieMascota("4", "", "", "", "", ref dsEspecies, ref sError);
                    {
                        if (dsEspecies.Tables.Count > 0)
                        {
                            DataData = dsEspecies.ToString();
                            //Llena Especies 
                            DropDownList listDropdown = new DropDownList();
                            listDropdown.ListaEspeciesAdd(dsEspecies);

                        }
                    }

                    break;

                case "Empresa":
                    ViewBag.message = "Lista de empresas proporcionados por el centro";
                    ViewBag.Nombre = "empresa";
                    DataSet dsPais = new DataSet();
                    DataSet dats = new DataSet();

                    crud.cEmpresaSociedad("4","","0","","","","","","","","","","0","","","","", ref ds, ref sError);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            DataData = ds.ToString();                           
                        }
                      
                        string mensaje = "";                        
                        crud.PaisesRegionComuna(ref dsPais, ref mensaje);
                        if (dsPais.Tables.Count > 0)
                        {
                            DataData = dsPais.ToString();                            
                            Models.DropDownList.PaisesRegComAdd(dsPais);

                        }
                    }
                    break;

                case "Centro":
                    ViewBag.message = "Lista de centros proporcionados por el centro";
                    ViewBag.Nombre = "centro";
                    DataSet dsPaisC = new DataSet();
                    DataSet dsEmpresa = new DataSet();
                    DataSet dsEstado = new DataSet();

                    crud.cCentroSociedad("4","", "", "0", "", "", "", "", "", "", "", "", "","","0", "", "", "","", ref ds, ref sError);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            DataData = ds.ToString();
                        }                        
                        string mensaje = "";                        
                        crud.PaisesRegionComuna(ref dsPaisC, ref mensaje);
                        if (dsPaisC.Tables.Count > 0)
                        {
                            DataData = dsPaisC.ToString();                            
                            Models.DropDownList.PaisesRegComAdd(dsPaisC);
                        }

                        crud.cEmpresaSociedad("4", "", "0", "", "", "", "", "", "", "", "", "", "0", "", "", "", "", ref dsEmpresa, ref sError);
                        {
                            if (dsEmpresa.Tables.Count > 0)
                            {
                                DataData = dsEmpresa.ToString();
                                //Llena Empresas 
                                DropDownList listDropdown = new DropDownList();
                                listDropdown.ListaEmpresasAdd(dsEmpresa);
                            }
                        }

                        crud.cEstadoSeccion("4", "centro","", "", "", "", ref dsEstado, ref sError);
                        {
                            if (dsEstado.Tables.Count > 0)
                            {
                                RadioButtonList radiobyttonList = new RadioButtonList();
                                radiobyttonList.ListaEstadoAdd(dsEstado);

                            }
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
           
            DataSet ds = new DataSet();
            string Error = "";
            try
            {
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
                            resultado = ds.Tables[0].Rows[0]["Codigo"].ToString() + "|" + ds.Tables[0].Rows[0]["Resultado"].ToString() + "|" + ds.Tables[0].Rows[0]["CodMant"].ToString();                      
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
                            resultado = ds.Tables[0].Rows[0]["Codigo"].ToString() + "|" + ds.Tables[0].Rows[0]["Resultado"].ToString() + "|" + ds.Tables[0].Rows[0]["CodMant"].ToString();
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
                            resultado = ds.Tables[0].Rows[0]["Codigo"].ToString() + "|" + ds.Tables[0].Rows[0]["Resultado"].ToString() + "|" + ds.Tables[0].Rows[0]["CodMant"].ToString();
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
                            resultado = ds.Tables[0].Rows[0]["Codigo"].ToString() + "|" + ds.Tables[0].Rows[0]["Resultado"].ToString() + "|" + ds.Tables[0].Rows[0]["CodMant"].ToString() + "|" + ds.Tables[0].Rows[0]["CodEsp"].ToString() + "|" + ds.Tables[0].Rows[0]["NomEsp"].ToString();
                        }
                    }
                }
            if (Mantenedor == "EMP")
                {
                    string RutRL="0";
                    string Dvrl = "";

                    string[] DatosEmpresa = Regis.Split('~');
                    string CodigoEmpresa = DatosEmpresa[0];
                    string RutEmpresa = DatosEmpresa[1];
                    string[] DatosRut = RutEmpresa.Split('-');
                    string Rut = DatosRut[0];
                    string Dv = DatosRut[1];
                    string RazonEmpresa = DatosEmpresa[2];
                    string GiroEmpresa = DatosEmpresa[3];
                    string DireccionEmp = DatosEmpresa[4];
                    string PaiEmp = DatosEmpresa[5];
                    string RegEmp = DatosEmpresa[6];
                    string ComEmp = DatosEmpresa[7];
                    
                    string TelefonoEmp = DatosEmpresa[8];
                    string EmailEmp = DatosEmpresa[9];
                    string RutRepLeg = DatosEmpresa[10];

                    if  (RutRepLeg != "")
                    {
                        string[] DatosRutRepLeg = RutRepLeg.Split('-');
                        RutRL = DatosRutRepLeg[0];
                        Dvrl = DatosRutRepLeg[1];
                    }

                 

                    string NomRepLeg = DatosEmpresa[11];
                
                    crud.cEmpresaSociedad(Accion, CodigoEmpresa, Rut, Dv, RazonEmpresa, GiroEmpresa, DireccionEmp, PaiEmp, RegEmp, ComEmp, TelefonoEmp, EmailEmp, RutRL, Dvrl, NomRepLeg, log_Update,log_Maquina, ref ds, ref Error);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            resultado = ds.Tables[0].Rows[0]["Datos"].ToString();
                        }
                    }
                }
            if (Mantenedor == "CEN")
                {


                    string[] DatosCentro = Regis.Split('~');
                    string CodigoCentro = DatosCentro[0];
                    string CodigoEmpresa = DatosCentro[1];
                    string RutCentro = DatosCentro[2];
                    string[] DatosRut = RutCentro.Split('-');
                    string RutC = DatosRut[0];
                    string DvC = DatosRut[1];
                    string RazonCentro = DatosCentro[3];
                    string GiroCentro = DatosCentro[4];
                    string DireccionCen = DatosCentro[5];
                    string PaiCen = DatosCentro[6];
                    string RegCen = DatosCentro[7];
                    string ComCen = DatosCentro[8];

                    string TelefonoCen = DatosCentro[9];
                    string EmailCen = DatosCentro[10];
                    string EstCentro = DatosCentro[11];
                    string RutContactoC = DatosCentro[12];
                    string RutContacto = "0";
                    string DvContacto = "";

                    if (RutContactoC != "")
                    {
                        string[] DatosContacto = RutContactoC.Split('-');
                        RutContacto = DatosContacto[0];
                        DvContacto = DatosContacto[1];
                    }

                    string NomContacto = DatosCentro[13];

                    crud.cCentroSociedad(Accion, CodigoCentro, CodigoEmpresa, RutC, DvC, RazonCentro, GiroCentro, DireccionCen, PaiCen, RegCen, ComCen, TelefonoCen, EmailCen, EstCentro, RutContacto, DvContacto, NomContacto, log_Update, log_Maquina, ref ds, ref Error);
                    {
                        if (ds.Tables.Count > 0)
                        {
                            resultado = ds.Tables[0].Rows[0]["Datos"].ToString();
                        }

                        if (Accion == "1")
                        {
                            string[] datosC = resultado.Split('|');
                            if (datosC[0] == "0")
                            { 
                            //crea carpeta o elimina carpeta
                                string ruta = @"C:\ImgVet\" + datosC[2];
                                    if (!Directory.Exists(ruta))
                                        {
                                        Console.WriteLine("Creando el directorio: {0}", ruta);
                                        DirectoryInfo di = Directory.CreateDirectory(ruta);
                                        }
                            }
                        }
                        if (Accion == "2")
                        {
                            string[] datosC = resultado.Split('|');
                            if (datosC[0] == "0")
                            {
                                //guarda o actualiza img de centro
                                string ruta = @"C:\ImgVet\" + datosC[2];
                                if (Directory.Exists(ruta))
                                {
                                    //Console.WriteLine("Creando el directorio: {0}", ruta);
                                    //DirectoryInfo di = Directory.CreateDirectory(ruta);
                                }
                            }
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
      
        //JSON

        public JsonResult GetRegion(string pai_Codigo)
        {
            var result = Models.DropDownList.ListRegion.Where(x => x.pai_CodigoPais == pai_Codigo).OrderBy(x => x.reg_Codigo).ToList();
            
            return Json(result);
        }

        public JsonResult GetComuna(string reg_Codigo)
            
        {
            reg_Codigo = reg_Codigo.Trim();
           var resultado = Models.DropDownList.ListComuna.Where(x => x.reg_CodigoRegion.Trim() == reg_Codigo).OrderBy(x => x.com_Codigo).ToList();
            return Json(resultado);
        }
        public JsonResult GetDatosEmpresa(string emp_Codigo)
        {
            DataSet dsEm = new DataSet();
            string sError = "";
            string resultado = "";

            try
            {

                crud.cEmpresaSociedad("0", emp_Codigo, "0", "", "", "", "", "", "", "", "", "", "0", "", "", "", "", ref dsEm, ref sError);
                {
                    if (dsEm.Tables.Count > 0)
                    {
                        resultado = dsEm.Tables[0].Rows[0]["emp_Rut"].ToString() + "-" + dsEm.Tables[0].Rows[0]["emp_Dv"].ToString() + "|" + dsEm.Tables[0].Rows[0]["emp_RazonS"].ToString() + "|" + dsEm.Tables[0].Rows[0]["emp_Giro"].ToString() + "|" +
                                    dsEm.Tables[0].Rows[0]["emp_Direccion"].ToString() + "|" + dsEm.Tables[0].Rows[0]["pai_Codigo"].ToString() + "|" + dsEm.Tables[0].Rows[0]["reg_Codigo"].ToString() + "|" + dsEm.Tables[0].Rows[0]["com_Codigo"].ToString() + "|" +
                                    dsEm.Tables[0].Rows[0]["emp_Telefono"].ToString() + "|" + dsEm.Tables[0].Rows[0]["emp_Email"].ToString() + "|" + dsEm.Tables[0].Rows[0]["emp_RutRepreLegal"].ToString() + "|" + dsEm.Tables[0].Rows[0]["emp_RepreLegal"].ToString();


                    }
                }
            }
            catch (Exception ex)
            {
            }

            return Json(resultado);

        }

        [HttpPost]
        public ActionResult actionacrear(IEnumerable<HttpPostedFileBase> filesImg)
        {
            try
            {
                string path = "";
                string FileName = "";

                if (filesImg != null)
                {
                    int numero =filesImg.Count();

                    foreach (HttpPostedFileBase file in filesImg)
                    {                      
                        string destino = @"C:\ImgVet\" + file.FileName ;
                        file.SaveAs(destino);
                      
                    }

                }
                }
            catch (Exception ex)
            {
              //  Utils.MostrarSweetAlert("Error", ex.Message, Utils.SweetAlertTipo.error);

            }

            return RedirectToAction("Perfil", "Profesional");

        }

    }
}

  

