using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WSAPP.Clases
{
    public class Conexion
    {

        SqlConnection con;
        string Conn;
        public Conexion()
        {
            if (con == null)
                con = conexion();
        }

        public SqlConnection conexion()
        {
            Conn = Constantes.ConexionString;
            return new SqlConnection(Conn);
        }
    }
}