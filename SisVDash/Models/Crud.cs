using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cnx.Data;
using System.Data;

namespace SisVDash.Models
{
    public class Crud
    {
        private string spathlog;
        string sconexion = System.Configuration.ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
        public string p_conexion
        {
            get
            {
                return sconexion;
            }
            set
            {
                sconexion = value;
            }
        }
        public string p_pathlog
        {
            get
            {
                return spathlog;
            }
            set
            {
                spathlog = value;
            }
        }
        private string sDb = "PVe";

        #region Login  
        public bool cIngresaUsuario(string log_Usuario, string log_Password, ref DataSet ds, ref string sError)
        {
            Cnx.Data.cConexion data;
            Cnx.Data.cParamDictionary param;
            Cnx.Data.cParam paramv;
            System.IO.StringReader CargaData;
            string sNomsp;
            string sDic;
            string sXmlErr = "";
            string sXmlOutput = "";
            bool breturn = false;

            try
            {
                sNomsp = "SPU_Login";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
                paramv.Add("log_Usuario", log_Usuario);
                paramv.Add("log_Password", log_Password);
                param.Add(sDic, paramv);
                if (!data.ExecSP(sNomsp, sDic, param, EoCType.TYPE_TRAN, ref sXmlErr, ref sXmlOutput))
                    throw new Exception(sXmlErr);
                CargaData = new System.IO.StringReader(sXmlOutput);
                ds = new System.Data.DataSet();
                ds.ReadXml(CargaData);
                breturn = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                data = null;
                param = null;

            }
            return breturn;
        }
        #endregion

        #region Color Mascota  
        public bool cColorMascota(string Accion, string col_Codigo, string col_Nombre, string log_Update,
                                  string log_Maquina, ref DataSet ds, ref string sError)
        {
            Cnx.Data.cConexion data;
            Cnx.Data.cParamDictionary param;
            Cnx.Data.cParam paramv;
            System.IO.StringReader CargaData;
            string sNomsp;
            string sDic;
            string sXmlErr = "";
            string sXmlOutput = "";
            bool breturn = false;

            try
            {
                sNomsp = "SPU_Color_Mascota_ADD";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
                paramv.Add("Accion", Accion);
                paramv.Add("col_Codigo", col_Codigo);
                paramv.Add("col_Nombre", col_Nombre);
                paramv.Add("log_Update", log_Update);
                paramv.Add("log_Maquina", log_Maquina);
                param.Add(sDic, paramv);
                if (!data.ExecSP(sNomsp, sDic, param, EoCType.TYPE_TRAN, ref sXmlErr, ref sXmlOutput))
                    throw new Exception(sXmlErr);
                CargaData = new System.IO.StringReader(sXmlOutput);
                ds = new System.Data.DataSet();
                ds.ReadXml(CargaData);
                breturn = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                data = null;
                param = null;

            }
            return breturn;
        }
        #endregion
        #region Especie Mascota  
        public bool cEspecieMascota(string Accion, string esp_Codigo, string esp_Nombre, string log_Update,
                                  string log_Maquina, ref DataSet ds, ref string sError)
        {
            Cnx.Data.cConexion data;
            Cnx.Data.cParamDictionary param;
            Cnx.Data.cParam paramv;
            System.IO.StringReader CargaData;
            string sNomsp;
            string sDic;
            string sXmlErr = "";
            string sXmlOutput = "";
            bool breturn = false;

            try
            {
                sNomsp = "SPU_Especie_ADD";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
                paramv.Add("Accion", Accion);
                paramv.Add("esp_Codigo", esp_Codigo);
                paramv.Add("esp_Nombre", esp_Nombre);
                paramv.Add("log_Update", log_Update);
                paramv.Add("log_Maquina", log_Maquina);
                param.Add(sDic, paramv);
                if (!data.ExecSP(sNomsp, sDic, param, EoCType.TYPE_TRAN, ref sXmlErr, ref sXmlOutput))
                    throw new Exception(sXmlErr);
                CargaData = new System.IO.StringReader(sXmlOutput);
                ds = new System.Data.DataSet();
                ds.ReadXml(CargaData);
                breturn = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                data = null;
                param = null;

            }
            return breturn;
        }
        #endregion
        #region Patrón Mascota  
        public bool cPatronMascota(string Accion, string pat_Codigo, string pat_Nombre, string log_Update,
                                  string log_Maquina, ref DataSet ds, ref string sError)
        {
            Cnx.Data.cConexion data;
            Cnx.Data.cParamDictionary param;
            Cnx.Data.cParam paramv;
            System.IO.StringReader CargaData;
            string sNomsp;
            string sDic;
            string sXmlErr = "";
            string sXmlOutput = "";
            bool breturn = false;

            try
            {
                sNomsp = "SPU_Patron_ADD";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
                paramv.Add("Accion", Accion);
                paramv.Add("pat_Codigo", pat_Codigo);
                paramv.Add("pat_Nombre", pat_Nombre);
                paramv.Add("log_Update", log_Update);
                paramv.Add("log_Maquina", log_Maquina);
                param.Add(sDic, paramv);
                if (!data.ExecSP(sNomsp, sDic, param, EoCType.TYPE_TRAN, ref sXmlErr, ref sXmlOutput))
                    throw new Exception(sXmlErr);
                CargaData = new System.IO.StringReader(sXmlOutput);
                ds = new System.Data.DataSet();
                ds.ReadXml(CargaData);
                breturn = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                data = null;
                param = null;

            }
            return breturn;
        }
        #endregion
        #region Raza Mascota  
        public bool cRazaMascota(string Accion, string raz_Codigo, string raz_Nombre, string esp_Codigo, string log_Update,
                                  string log_Maquina, ref DataSet ds, ref string sError)
        {
            Cnx.Data.cConexion data;
            Cnx.Data.cParamDictionary param;
            Cnx.Data.cParam paramv;
            System.IO.StringReader CargaData;
            string sNomsp;
            string sDic;
            string sXmlErr = "";
            string sXmlOutput = "";
            bool breturn = false;

            try
            {
                sNomsp = "SPU_Raza_ADD";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
                paramv.Add("Accion", Accion);
                paramv.Add("raz_Codigo", raz_Codigo);
                paramv.Add("raz_Nombre", raz_Nombre);
                paramv.Add("esp_Codigos", esp_Codigo);
                paramv.Add("log_Update", log_Update);
                paramv.Add("log_Maquina", log_Maquina);
                param.Add(sDic, paramv);
                if (!data.ExecSP(sNomsp, sDic, param, EoCType.TYPE_TRAN, ref sXmlErr, ref sXmlOutput))
                    throw new Exception(sXmlErr);
                CargaData = new System.IO.StringReader(sXmlOutput);
                ds = new System.Data.DataSet();
                ds.ReadXml(CargaData);
                breturn = true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                data = null;
                param = null;

            }
            return breturn;
        }
        #endregion
    }
}