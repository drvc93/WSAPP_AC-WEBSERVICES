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

                    listSoc.Add(sc);

                }


            }

            return listSoc.ToArray();



        }


        #endregion
    }
}
