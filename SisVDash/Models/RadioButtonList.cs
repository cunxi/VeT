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
    public class RadioButtonList
    {
        public static List<SelectListItem> ListaEstados { get; set; }
        public void ListaEstadoAdd(DataSet ds)
        {
            ListaEstados = new List<SelectListItem>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListaEstados.Add(new SelectListItem()
                {
                    Value = row["est_Cod_Est_Sec"].ToString(),
                    Text = row["est_Descripcion"].ToString()
                });
            }
        }
    }
  
}