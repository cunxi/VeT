﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;

namespace SisV.Controllers
{
    public class MenuController : Controller
    {
        Models.Crud crud = new Models.Crud();

        // GET: Menu
        public ActionResult Inicio()
        {
            DataSet ds = new DataSet();
            string Mensaje = "";
            crud.Inicio(ref ds, ref Mensaje);
            return View(ds);
        }

        public ActionResult Busqueda()
        {
            return RedirectToAction("Inicio", "Menu");
        }

        [HttpPost]
        public ActionResult Busqueda(string Texto, string Ubicacion, string Categoria)
        {
            ViewBag.Cant = 0;
            DataSet ds = new DataSet();
            string Mensaje = "";
            crud.Busqueda_Centro(Texto, Ubicacion, Categoria, ref ds, ref Mensaje);

            if (ds.Tables.Count > 0) { ViewBag.Cant = ds.Tables[0].Rows.Count; }

            return View(ds);
        }

        public ActionResult Busqueda_Sidebar()
        {
            ViewBag.Cant = 0;
            return View();
        }

        public ActionResult Centro(string ID_Centro)
        {
            DataSet ds = new DataSet();
            string Mensaje = "";

            if (ID_Centro != null && ID_Centro != "")
            {
                crud.Centro(ID_Centro, ref ds, ref Mensaje);

                foreach (DataTable table in ds.Tables)
                {
                    if (table.TableName == "SPU_VistaCentro4")
                    {
                        Models.ListDropdownList.Horarios_CentroADD(ds.Tables["SPU_VistaCentro4"]);
                    }
                }

                return View(ds);
            }
            else
            {
                return RedirectToAction("Inicio", "Menu");
            }
        }

        public ActionResult Paises()
        {
            DataSet ds = new DataSet();
            string mensaje = "";
            crud.PaisesRegionComuna(ref ds, ref mensaje);
            Models.ListDropdownList.PaisesRegComAdd(ds);
            return View();
        }


        public ActionResult RegistroPaso2(string Nombre, string Apellidos, string Email, string Contrasena)
        {
            try
            {
                DataSet ds = new DataSet();
                string mensaje = "";
                string[] apelliidos_ = Apellidos.Split(' ');
                string apellido_P = apelliidos_[0].ToString();
                string apellido_M = "";
                if (apelliidos_.Length > 1) { apellido_M = apelliidos_[1].ToString(); }
                crud.RegistrarCliente(Nombre, apellido_P, apellido_M, Email, Contrasena, ref ds, ref mensaje);

                Models.Result result = new Models.Result();
                if (ds.Tables.Count > 0 && ds.Tables[0].Columns.Count > 2)
                {
                    result.Codigo = 0;
                    result.Mensaje = "Registro Exitoso";
                    return View(ds);
                }
                else
                {
                    result.Codigo = Convert.ToInt32(ds.Tables[0].Rows[0]["Codigo"].ToString());
                    result.Mensaje = ds.Tables[0].Rows[0]["Resultado"].ToString();
                    return RedirectToAction("Inicio", "Menu");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Inicio", "Menu");
            }

        }

        [HttpPost]
        public ActionResult RegistroFinal(HttpPostedFileBase log_Imagen, string cli_ID_Cliente, string log_ID_Login, string Identificador, string cli_Direccion, string cli_Telefono, string log_Usuario)
        {
            DataSet ds_Imegn = new DataSet();
            DataSet ds_Cliente = new DataSet();
            string Mensaje_Imagen = "";
            string Mensaje_Cliente = "";
            string srcImagen = "";
            if (log_Imagen != null)
            {
                if (log_Imagen.FileName.Contains("\\") == true)
                {
                    srcImagen = Path.Combine(Server.MapPath("~/Content/ImagesPerfil/"), cli_ID_Cliente + ".png");
                    if (System.IO.File.Exists(srcImagen))
                        System.IO.File.Delete(srcImagen);

                    log_Imagen.SaveAs(srcImagen);

                }
                else
                {
                    srcImagen = Path.Combine(Server.MapPath("~/Content/ImagesPerfil/"), cli_ID_Cliente + ".png");

                    if (System.IO.File.Exists(srcImagen))
                        System.IO.File.Delete(srcImagen);

                    log_Imagen.SaveAs(srcImagen);

                }
                crud.Actualizar_Foto(log_ID_Login, "/Content/ImagesPerfil/" + cli_ID_Cliente + ".png", ref ds_Imegn, ref Mensaje_Imagen);
                srcImagen = "/Content/ImagesPerfil/" + cli_ID_Cliente + ".png";
            }
            else
            {
                srcImagen = "/Content/images/perfil-defualt.png";
            }

            string[] dividerRut = Identificador.Split('-');
            string Rut = dividerRut[0].Replace(".", "");
            string Dv = dividerRut[1];

            crud.RegistrarCliente_Paso2(cli_ID_Cliente, Rut, Dv, cli_Telefono, cli_Direccion, log_Usuario, ref ds_Cliente, ref Mensaje_Cliente);

            Models.Usuario usuario = new Models.Usuario
            {
                ID = ds_Cliente.Tables[0].Rows[0]["cli_ID_Cliente"].ToString(),
                Nombres = ds_Cliente.Tables[0].Rows[0]["cli_Nombres"].ToString(),
                Apellidos = ds_Cliente.Tables[0].Rows[0]["cli_Apellido_P"].ToString() + " " + ds_Cliente.Tables[0].Rows[0]["cli_Apellido_P"].ToString(),
                Identificador = ds_Cliente.Tables[0].Rows[0]["cli_Rut"].ToString() + "-" + ds_Cliente.Tables[0].Rows[0]["cli_Dv"].ToString(),
                Telefono = ds_Cliente.Tables[0].Rows[0]["cli_Telefono"].ToString(),
                Direccion = ds_Cliente.Tables[0].Rows[0]["cli_Direccion"].ToString(),
                Imagen = srcImagen,
                log_ID_Login = log_ID_Login,
                Level = Convert.ToInt32(ds_Cliente.Tables[0].Rows[0]["cli_Level"].ToString())
            };
            Utils.GuardarUsuarioSesion(usuario);

            return RedirectToAction("Inicio", "Menu");
        }


        public ActionResult Promociones()
        {
            return View();
        }

        public ActionResult Opinion(string ID_Centro, string Opinion, string servicio, string costos, string higiene, string atencion)
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Models.Usuario usuario = new Models.Usuario();
            return RedirectToAction("Inicio", "Menu");
        }



        //JSON

        public JsonResult GetRegion(string pai_Codigo)
        {
            var result = Models.ListDropdownList.ListRegion.Where(x => x.pai_CodigoPais == pai_Codigo).OrderBy(x => x.reg_Codigo).ToList();
            return Json(result);
        }


        public JsonResult Login(string Usuario, string Password)
        {
            DataSet ds = new DataSet();
            string Mensaje = "";
            crud.cIngresaUsuario(Usuario, Password, ref ds, ref Mensaje);
            Models.Result result = new Models.Result();
            if (ds.Tables.Count > 0 && ds.Tables[0].Columns.Count > 2)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["cli_Level"].ToString()) == 2)
                {
                    FormsAuthentication.SetAuthCookie(ds.Tables[0].Rows[0]["cli_ID_Cliente"].ToString(), true);

                    Models.Usuario usuario = new Models.Usuario
                    {
                        ID = ds.Tables[0].Rows[0]["cli_ID_Cliente"].ToString(),
                        Nombres = ds.Tables[0].Rows[0]["cli_Nombres"].ToString(),
                        Apellidos = ds.Tables[0].Rows[0]["cli_Apellidos"].ToString(),
                        Identificador = ds.Tables[0].Rows[0]["cli_Identificador"].ToString(),
                        Telefono = ds.Tables[0].Rows[0]["cli_Telefono"].ToString(),
                        Correo = ds.Tables[0].Rows[0]["cli_Email"].ToString(),
                        Direccion = ds.Tables[0].Rows[0]["cli_Direccion"].ToString(),
                        Imagen = ds.Tables[0].Rows[0]["log_Imagen"].ToString(),
                        log_ID_Login = ds.Tables[0].Rows[0]["log_ID_Login"].ToString(),
                        Level = Convert.ToInt32(ds.Tables[0].Rows[0]["cli_Level"].ToString())
                    };
                    Utils.GuardarUsuarioSesion(usuario);
                    result.Codigo = 0;
                    result.Mensaje = "Usuario Exitoso";
                }
            }
            else
            {
                result.Codigo = Convert.ToInt32(ds.Tables[0].Rows[0]["Codigo"].ToString());
                result.Mensaje = ds.Tables[0].Rows[0]["Resultado"].ToString();
            }

            return Json(result);

        }

        public JsonResult GetUsuario(string Usuario)
        {
            DataSet ds = new DataSet();
            string Mensaje = "";
            crud.Validar_Usuario(Usuario, ref ds, ref Mensaje);

            Models.Result result = new Models.Result();
            result.Mensaje = ds.Tables[0].Rows[0]["Resultado"].ToString();
            result.Codigo = Convert.ToInt32(ds.Tables[0].Rows[0]["Codigo"].ToString());
            return Json(result);
        }

        public JsonResult GetHorarioFecha(string Fecha)
        {
            DateTime _Fecha = Convert.ToDateTime(Fecha, new CultureInfo("es-ES"));
            var result = Models.ListDropdownList.horario_Centros.Where(x => x.Fecha == _Fecha).ToList();
            string div = "";
            int i = 1;
            if (result[0].horas != null) {
                foreach (var hora in result[0].horas)
                {
                    string id = "time-slot-" + i;
                    div += @"<div class='time-slot'>
                        <input type='radio' name='time-slot' id='" + id + @"'>       
                            <label for='" + id + @"'>
                            <strong>" + hora + @"</strong>
                            </label>
                        </div>";
                    i = i + 1;
                }
            }
            else
            {
                div = @"<a href='#'>Cerrado</a>";
            }

            return Json(div);
        }
    }
}