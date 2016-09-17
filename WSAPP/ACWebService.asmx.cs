using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSAPP.Clases;
using System.Data.SqlClient;
using System.Data;

namespace WSAPP
{
    /// <summary>
    /// Descripción breve de ACWebService
    /// </summary>
    /// 
    
    [WebService(Namespace = "http://drvc2110-001-site2.btempurl.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]


    public class ACWebService : System.Web.Services.WebService
    {


        Conexion con = new Conexion();
        
        #region ACMENCONLE
        
        [WebMethod]

        public Socio[] GetUsuario(string acccion , string username, string password) 
        {
            List<Socio> listSoc = new List<Socio>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_LISTAR_SOCIO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", acccion);
            dap.SelectCommand.Parameters.AddWithValue("@userName", username);
            dap.SelectCommand.Parameters.AddWithValue("@pass", password);
            dap.Fill(dt);
            cn.Close();

            if  (dt!= null)
            {

                for (int i =  0; i < dt.Rows.Count; i++)
                {

                    Socio sc = new Socio();
                    sc.CodSocio =  Convert.ToInt32( dt.Rows[i]["CodigoSocio"].ToString());
                    sc.Dni = dt.Rows[i]["Dni"].ToString();
                    sc.Nombres = dt.Rows[i]["Nombres"].ToString();
                    sc.ApellidoPat = dt.Rows[i]["ApellidoPat"].ToString();
                    sc.ApellidoMat  = dt.Rows[i]["ApellidoMat"].ToString();
                    sc.Puesto= dt.Rows[i]["Puesto"].ToString();
                    sc.Celular = dt.Rows[i]["Celular"].ToString();
                    sc.FechaRegistro = dt.Rows[i]["FechaRegistro"].ToString();
                    sc.Estado = dt.Rows[i]["Estado"].ToString();
                    sc.Correo = dt.Rows[i]["Correo"].ToString();
                    sc.TipoUsuario  = dt.Rows[i]["Tipo"].ToString();

                    listSoc.Add(sc);

                }


            }

            return listSoc.ToArray();



        }

        [WebMethod]
        public Seccion[] GetSecciones(string accion, string codSeccion) {

            List<Seccion> listSecc = new List<Seccion>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_LISTAR_SECCIONES", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codSeccion", codSeccion);
            
            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Seccion sec = new Seccion();
                    sec.Codigo = dt.Rows[i]["CodigoSeccion"].ToString();
                    sec.Descripcion = dt.Rows[i]["DescripSeccion"].ToString();
                    sec.Fecha = dt.Rows[i]["Fecha"].ToString();
                   

                    listSecc.Add(sec);

                }


            }

            return listSecc.ToArray();





        }

        [WebMethod]

        public string InserSocio(string accion,string codSocio ,string dni, string nombres, string apePat , string apeMat ,
                                    string puesto, string celular,string tipoUs,string userReg,string correo)
        {
            string res = "";
             SqlConnection cn = con.conexion();
            SqlCommand sqlcmd = new SqlCommand("SPI_AC_SOCIO", cn);
            sqlcmd.Connection = cn;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            cn.Open();

            sqlcmd.Parameters.AddWithValue("@accion", accion);
           
            sqlcmd.Parameters.AddWithValue("@dni", dni);
            sqlcmd.Parameters.AddWithValue("@nombres", nombres.Trim().ToUpper());
            sqlcmd.Parameters.AddWithValue("@apePat", apePat.Trim().ToUpper());
            sqlcmd.Parameters.AddWithValue("@apeMat", apeMat.Trim().ToUpper());
            sqlcmd.Parameters.AddWithValue("@puesto", puesto);
            sqlcmd.Parameters.AddWithValue("@celular", celular);
            sqlcmd.Parameters.AddWithValue("@tipoUs", tipoUs);
            sqlcmd.Parameters.AddWithValue("@userReg", userReg);
            sqlcmd.Parameters.AddWithValue("@correo", correo);

            if (accion == "NEW")
            {

                SqlParameter result = sqlcmd.Parameters.Add("@codigoSocio", SqlDbType.Int);
                result.Direction = ParameterDirection.Output;
                result.Size = 100;
                sqlcmd.ExecuteNonQuery();
                int parRes = (int)sqlcmd.Parameters["@codigoSocio"].Value;
                res = Convert.ToString(parRes);
            }

            else
            {
                sqlcmd.Parameters.AddWithValue("@accion", accion);
                res = Convert.ToString(sqlcmd.ExecuteNonQuery());

            }


            return res;




        }

        [WebMethod]
        public string  InsertSocioSeccion(string codSocio , string codSeccion)
        {

            string res = "NO";
            SqlConnection cn = con.conexion();
            SqlCommand sqlcmd = new SqlCommand("SPI_AC_SECCION_SOCIO", cn);
            sqlcmd.Connection = cn;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            cn.Open();

            sqlcmd.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
            sqlcmd.Parameters.AddWithValue("@codSeccion", Convert.ToInt32(codSeccion));
        
                int  var = sqlcmd.ExecuteNonQuery();
            if (var > 0)
            {
                res = "OK";

            }
            


            return res;



        }


        #endregion
    }
}
