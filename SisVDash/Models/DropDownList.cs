using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SisVDash.Models;
using Cnx.Data;
using System.Data;
using System.Web.Mvc;

namespace SisVDash.Models
{
    public class DropDownList
    {
        public static List<SelectListItem> ListaEmpresas { get; set; }
        public static List<SelectListItem> ListaEspecies { get; set; }
        public static List<SelectListItem> ListaRegion { get; set; }
        public static List<SelectListItem> ListaComuna { get; set; }
        public static List<SelectListItem> ListaPaises { get; set; }
        public static List<Region> ListRegion { get; set; }
        public static List<Comuna> ListComuna { get; set; }

        public class Region
        {
            public string pai_CodigoPais { get; set; }
            public string reg_Codigo { get; set; }
            public string reg_Nombre { get; set; }
        }
        public class Comuna
        {
            public string reg_CodigoRegion { get; set; }
            public string com_Codigo { get; set; }
            public string com_Nombre { get; set; }
        }
        public void ListaEmpresasAdd(DataSet ds)
        {
            ListaEmpresas = new List<SelectListItem>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListaEmpresas.Add(new SelectListItem()
                {
                    Value = row["emp_ID_Empresa"].ToString(),
                    Text = row["emp_RazonS"].ToString()
                });
            }
        }

        public void ListaEspeciesAdd(DataSet ds)
        {
            ListaEspecies = new List<SelectListItem>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListaEspecies.Add(new SelectListItem()
                {
                    Value = row["esp_Codigo"].ToString(),
                    Text = row["esp_Nombre"].ToString()
                });
            }
        }
      
        public static void PaisesRegComAdd(DataSet ds)
        {

            ListaPaises = new List<SelectListItem>();
            ListRegion = new List<Region>();
            ListComuna = new List<Comuna>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListaPaises.Add(new SelectListItem() { Value = row["pai_Codigo"].ToString().Trim(), Text = row["pai_Nombre"].ToString() });
            }

            foreach (DataRow row in ds.Tables[1].Rows)
            {
                Region region = new Region();
                region.pai_CodigoPais = row["pai_CodigoPais"].ToString();
                region.reg_Codigo = row["reg_Codigo"].ToString().Trim();
                region.reg_Nombre = row["reg_Nombre"].ToString();
                ListRegion.Add(region);
            }

            foreach (DataRow row in ds.Tables[2].Rows)
            {
                Comuna comuna = new Comuna();
                comuna.reg_CodigoRegion = row["reg_CodigoRegion"].ToString().Trim();
                comuna.com_Codigo = row["com_Codigo"].ToString().Trim();
                comuna.com_Nombre = row["com_Nombre"].ToString();
                ListComuna.Add(comuna);
            }

        }
    }


 
}