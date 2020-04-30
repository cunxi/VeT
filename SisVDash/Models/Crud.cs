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
                paramv.Add("esp_Codigo", esp_Codigo);
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

        #region Empresa Sociedad  
        public bool cEmpresaSociedad(string Accion, string emp_ID_Empresa, string emp_Rut, string emp_Dv, string emp_RazonS, string emp_Giro, string emp_Direccion,
                                     string pai_Codigo, string reg_Codigo, string com_Codigo,string emp_Telefono, string emp_Email, string emp_RutRepreLegal, 
                                     string emp_DvRepreLegal, string emp_RepreLegal, string log_Update,string log_Maquina, ref DataSet ds, ref string sError)
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
                emp_RutRepreLegal = emp_RutRepreLegal.Trim();
                if (emp_RutRepreLegal == "")
                {
                    emp_RutRepreLegal = "0";
                }

                sNomsp = "SPU_Empresa_ADD";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
                paramv.Add("Accion", Accion);
                paramv.Add("emp_ID_Empresa", emp_ID_Empresa);
                paramv.Add("emp_Rut", emp_Rut);
                paramv.Add("emp_Dv", emp_Dv);
                paramv.Add("emp_RazonS", emp_RazonS);
                paramv.Add("emp_Giro", emp_Giro);
                paramv.Add("emp_Direccion", emp_Direccion);
                paramv.Add("pai_Codigo", pai_Codigo);
                paramv.Add("reg_Codigo", reg_Codigo);
                paramv.Add("com_Codigo", com_Codigo);
                paramv.Add("emp_Telefono", emp_Telefono);
                paramv.Add("emp_Email", emp_Email);
                paramv.Add("emp_RutRepreLegal", emp_RutRepreLegal);
                paramv.Add("emp_DvRepreLegal", emp_DvRepreLegal);
                paramv.Add("emp_RepreLegal", emp_RepreLegal);
             
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
        #region Centro Sociedad  
        public bool cCentroSociedad(string Accion, string cen_ID_Centro,string emp_ID_Empresa, string cen_Rut, string cen_Dv, string cen_RazonS, string cen_Giro, string cen_Direccion,
                                     string pai_Codigo, string reg_Codigo, string com_Codigo, string cen_Telefono, string cen_Email, string est_Cod_Estado, string cen_RutContacto,
                                     string cen_DvContacto,string cen_Contacto, string log_Update, string log_Maquina, ref DataSet ds, ref string sError)
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
                cen_RutContacto = cen_RutContacto.Trim();
                if (cen_RutContacto == "")
                {
                    cen_RutContacto = "0";
                }

                sNomsp = "SPU_Centro_ADD";
                sDic = "Consulta";
                data = new Cnx.Data.cConexion();
                data.sCon = sconexion;
                param = new Cnx.Data.cParamDictionary();
                paramv = new Cnx.Data.cParam(sDb, sNomsp);
                paramv.Add("Accion", Accion);
                paramv.Add("cen_ID_Centro", cen_ID_Centro);
                paramv.Add("emp_ID_Empresa", emp_ID_Empresa);
                paramv.Add("cen_Rut", cen_Rut);
                paramv.Add("cen_Dv", cen_Dv);
                paramv.Add("cen_RazonS", cen_RazonS);
                paramv.Add("cen_Giro", cen_Giro);
                paramv.Add("cen_Direccion", cen_Direccion);
                paramv.Add("pai_Codigo", pai_Codigo);
                paramv.Add("reg_Codigo", reg_Codigo);
                paramv.Add("com_Codigo", com_Codigo);
                paramv.Add("cen_Telefono", cen_Telefono);
                paramv.Add("cen_Email", cen_Email);
                paramv.Add("est_Cod_Estado", est_Cod_Estado);
                paramv.Add("cen_RutContacto", cen_RutContacto);
                paramv.Add("cen_DvContacto", cen_DvContacto);
                paramv.Add("cen_Contacto", cen_Contacto);              
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

        #region Pais,región y comuna

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