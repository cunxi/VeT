using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisV.Controllers
{
    public class MenuController : Controller
    {

        // GET: Menu
        public ActionResult Inicio()
        {
            Models.Crud crud = new Models.Crud();
            DataSet ds = new DataSet();
            string Mensaje = "";
            crud.Inicio(ref ds, ref Mensaje);
            return View(ds);
        }

        public ActionResult Busqueda()
        {
            return View();
        }
        public ActionResult Centro()
        {
            return View();
        }
     
    }
}