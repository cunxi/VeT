using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        public static List<Horario_Centro> horario_Centros { get; set; }
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

        public static void Horarios_CentroADD(DataTable dt)
        {
            horario_Centros = new List<Horario_Centro>();
            DateTime FechaInicio = DateTime.Today;
            DateTime FechaTermino = DateTime.Today.AddMonths(1);

            for (DateTime d = FechaInicio; d <= FechaTermino; d = d.AddDays(1))
            {
                Horario_Centro _Centro = new Horario_Centro();
                _Centro.Fecha = d;

                string nombre_dia = d.ToString("dddd", new CultureInfo("es-ES"));

                foreach (DataRow row in dt.Rows)
                {
                    if (row["hor_Dia_Nombre"].ToString().ToLower() == nombre_dia)
                    {
                        if (row["hor_Activo"].ToString() == "true") {
                            DateTime HoraInicio = Convert.ToDateTime(row["hor_HoraInicio"], new CultureInfo("es-ES"));
                            DateTime HoraTermino = Convert.ToDateTime(row["hor_HoraTermino"], new CultureInfo("es-ES"));
                            int minutos = Convert.ToInt32(row["hor_Atencion_Min"].ToString());

                            _Centro.horas = new List<string>();
                            for (DateTime time = HoraInicio; time <= HoraTermino; time = time.AddMinutes(minutos))
                            {
                                _Centro.horas.Add(time.ToString("HH:mm", new CultureInfo("es-ES")));
                            }
                        }
                    }
                }
                horario_Centros.Add(_Centro);
            }

        }

    }
}