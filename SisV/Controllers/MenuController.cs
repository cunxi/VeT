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
            return View();
        }
        public ActionResult Centro(string ID_Centro)
        {
            DataSet ds = new DataSet();
            string Mensaje = "";

            if (ID_Centro != null && ID_Centro != "") {
                crud.Centro(ID_Centro, ref ds, ref Mensaje);
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


        //JSON

        public JsonResult GetRegion(string pai_Codigo)
        {
            var result = Models.ListDropdownList.ListRegion.Where(x=> x.pai_CodigoPais == pai_Codigo).OrderBy(x => x.reg_Codigo).ToList();
            return Json(result);
        }
     
    }
}