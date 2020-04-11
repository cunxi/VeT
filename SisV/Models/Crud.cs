using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cnx.Data;
using System.Data;

namespace SisV.Models
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

       
        #region SPU_Inicio
        public bool Inicio(ref DataSet ds, ref string sError)
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
                sNomsp = "SPU_VistaInicio";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
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
        public bool Centro(string ID_Centro,ref DataSet ds, ref string sError)
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
                sNomsp = "SPU_VistaCentro";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
                paramv.Add("ID_Centro", ID_Centro);
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
        #region #SPU_Centro

        #endregion

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

        #region SPU_PAISES REGION COMUNA

        public bool PaisesRegionComuna(ref DataSet ds, ref string sError)
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
                sNomsp = "SPU_PaisesRegionComuna";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
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