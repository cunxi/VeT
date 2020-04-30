using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisV.Models
{
    public class ListDropdownList
    {

        public static List<SelectListItem> ListaRegion { get; set; }
        public static List<SelectListItem> ListaComuna { get; set; }
        public static List<SelectListItem> ListaPaises { get; set; }
        public static List<Region> ListRegion { get; set; }
        public static List<Comuna> ListComuna { get; set; } 

        public static void PaisesRegComAdd(DataSet ds)
        {

            ListaPaises = new List<SelectListItem>();
            ListRegion = new List<Region>();
            ListComuna = new List<Comuna>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListaPaises.Add(new SelectListItem() { Value = row["pai_Codigo"].ToString(), Text = row["pai_Nombre"].ToString() });
            }

            foreach (DataRow row in ds.Tables[1].Rows)
            {
                Region region = new Region();
                region.pai_CodigoPais = row["pai_CodigoPais"].ToString();
                region.reg_Codigo = row["reg_Codigo"].ToString();
                region.reg_Nombre = row["reg_Nombre"].ToString();
                ListRegion.Add(region);
            }

            foreach (DataRow row in ds.Tables[2].Rows)
            {
                Comuna comuna = new Comuna();
                comuna.reg_CodigoRegion = row["reg_CodigoRegion"].ToString();
                comuna.com_Codigo = row["com_Codigo"].ToString();
                comuna.com_Nombre = row["com_Nombre"].ToString();
                ListComuna.Add(comuna);
            }

        }

    }
}