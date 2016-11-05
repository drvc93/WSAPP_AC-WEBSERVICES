using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSAPP.Clases;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;

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

        public Socio[] GetUsuario(string acccion, string username, string password)
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

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Socio sc = new Socio();
                    sc.CodSocio = Convert.ToInt32(dt.Rows[i]["CodigoSocio"].ToString());
                    sc.Dni = dt.Rows[i]["Dni"].ToString();
                    sc.Nombres = dt.Rows[i]["Nombres"].ToString();
                    sc.ApellidoPat = dt.Rows[i]["ApellidoPat"].ToString();
                    sc.ApellidoMat = dt.Rows[i]["ApellidoMat"].ToString();
                    sc.Puesto = dt.Rows[i]["Puesto"].ToString();
                    sc.Celular = dt.Rows[i]["Celular"].ToString();
                    sc.FechaRegistro = dt.Rows[i]["FechaRegistro"].ToString();
                    sc.Estado = dt.Rows[i]["Estado"].ToString();
                    sc.Correo = dt.Rows[i]["Correo"].ToString();
                    sc.TipoUsuario = dt.Rows[i]["Tipo"].ToString();

                    listSoc.Add(sc);

                }


            }

            return listSoc.ToArray();



        }

        [WebMethod]

        public SocioPuesto[] getSociosPuesto(string accion, string CodSocio)
        {

            List<SocioPuesto> listSoc = new List<SocioPuesto>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_LISTAR_SOCIO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codSociodet", Convert.ToInt32(CodSocio));

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    SocioPuesto sc = new SocioPuesto();
                    sc.CodSocio = dt.Rows[i]["CodigoSocio"].ToString();
                    sc.NroPuesto = dt.Rows[i]["NumeroPuesto"].ToString();
                    sc.Estado = dt.Rows[i]["Estado"].ToString();
                    sc.FechaReg = dt.Rows[i]["FechaaReg"].ToString();
                    sc.UserReg = dt.Rows[i]["UserReg"].ToString();
                    sc.CodSeccion = dt.Rows[i]["CodigoSeccion"].ToString();





                    listSoc.Add(sc);

                }


            }

            return listSoc.ToArray();

        }




        [WebMethod]

        public ConceptoPago[] GetConceptosPago(string accion, string codConcepto)
        {

            List<ConceptoPago> listaConcepto = new List<ConceptoPago>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_LISTAR_CONCEPTO_PAGO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codConcepto", Convert.ToInt32(codConcepto));

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    ConceptoPago c = new ConceptoPago();
                    c.CodConcepto = dt.Rows[i]["CodConcepto"].ToString();
                    c.Descripcion = dt.Rows[i]["Descripcion"].ToString();
                    c.Monto = dt.Rows[i]["Monto"].ToString();
                    c.UserReg = dt.Rows[i]["UserReg"].ToString();
                    c.FechaReg = dt.Rows[i]["FechaReg"].ToString();



                    listaConcepto.Add(c);

                }


            }

            return listaConcepto.ToArray();

        }

        [WebMethod]

        public string GetSeccionFromSocio(string accion, string codSocio, string nroPuesto)
        {


            string result = "";

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_CONSULTAS_GENERALES", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);

            dap.SelectCommand.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
            dap.SelectCommand.Parameters.AddWithValue("@nroPuesto", Convert.ToInt32(nroPuesto));


            dap.Fill(dt);
            cn.Close();

            if (dt != null && dt.Rows.Count > 0)
            {


                result = dt.Rows[0]["Seccion"].ToString();



            }



            return result;



        }
        [WebMethod]
        public string VerificarDeudaSocio(string accion, string codSocio, string nroPuesto)
        {
            decimal monto = 0;
            string result = "";
            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_CONSULTA_SALDOS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
            dap.SelectCommand.Parameters.AddWithValue("@nroPuesto", Convert.ToInt32(nroPuesto));

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    monto = Convert.ToDecimal(dt.Rows[i]["Monto"].ToString());

                    /*  add  object*/



                }


            }
            else
            {
                result = "Error";
            }

            if (monto > 0)
            {

                result = Convert.ToString(monto);

            }

            return result;

        }


        [WebMethod]

        public DetalleSaldo[] GetDetalleSaldo(string accion, string codSocio, string nroPuesto)
        {
            List<DetalleSaldo> listDet = new List<DetalleSaldo>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_CONSULTA_SALDOS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
            dap.SelectCommand.Parameters.AddWithValue("@nroPuesto", Convert.ToInt32(nroPuesto));

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DetalleSaldo d = new DetalleSaldo();
                    d.CodConcepto = dt.Rows[i]["codConcepto"].ToString();
                    d.Mes = dt.Rows[i]["mes"].ToString();
                    d.Anio = dt.Rows[i]["anio"].ToString();
                    d.Estado = dt.Rows[i]["estado"].ToString();
                    d.Monto = dt.Rows[i]["monto"].ToString();

                    /*  add  object*/
                    listDet.Add(d);


                }







            }

            return listDet.ToArray();

        }


        [WebMethod]
        public SaldoConcepto[] GetSaldoPorConceptos(string accion, string codSocio, string nroPuesto)
        {


            List<SaldoConcepto> listC = new List<SaldoConcepto>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_CONSULTA_SALDOS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
            dap.SelectCommand.Parameters.AddWithValue("@nroPuesto", Convert.ToInt32(nroPuesto));

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {



                SaldoConcepto c1 = new SaldoConcepto("1", dt.Rows[0]["debeVigilancia"].ToString(), dt.Rows[0]["PagoVigilancia"].ToString());
                SaldoConcepto c2 = new SaldoConcepto("2", dt.Rows[0]["debeAguaLuz"].ToString(), dt.Rows[0]["PagoAguaLuz"].ToString());
                SaldoConcepto c3 = new SaldoConcepto("3", dt.Rows[0]["debeSrvComunes"].ToString(), dt.Rows[0]["SrvComunes"].ToString());

                listC.Add(c1);
                listC.Add(c2);
                listC.Add(c3);




            }

            return listC.ToArray();



        }


        [WebMethod]
        public Banco[] GetBancos(string accion, string codBanco)
        {
            List<Banco> listBanco = new List<Banco>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_LISTAR_BANCOS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codBanco", Convert.ToInt32(codBanco));

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Banco b = new Banco();
                    b.CodBanco = dt.Rows[i]["codBanco"].ToString();
                    b.NombreLargo = dt.Rows[i]["NombreLargo"].ToString();
                    b.NombreCorto = dt.Rows[i]["NombreCorto"].ToString();
                    b.NroCuenta = dt.Rows[i]["NroCuenta"].ToString();


                    listBanco.Add(b);

                }


            }

            return listBanco.ToArray();


        }

        [WebMethod]
        public Seccion[] GetSecciones(string accion, string codSeccion, string codSocio)
        {

            List<Seccion> listSecc = new List<Seccion>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_LISTAR_SECCIONES", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codSeccion", codSeccion);
            dap.SelectCommand.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));

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

        public string InserSocio(string accion, string codSocio, string dni, string nombres, string apePat, string apeMat,
                                    string puesto, string celular, string tipoUs, string userReg, string correo)
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
                int parRes = (int) sqlcmd.Parameters["@codigoSocio"].Value;
                res = Convert.ToString(parRes);
            }

            else
            {
                sqlcmd.Parameters.AddWithValue("@codigoSocio", Convert.ToInt32(codSocio));
                sqlcmd.ExecuteNonQuery();
                res = Convert.ToString(codSocio);

            }


            return res;




        }

        [WebMethod]
        public string InsertSocioPuesto(string codSocio, string nroPuesto, string codSeccion, string userReg)
        {

            string res = "NO";

            if (InsertPuesto(nroPuesto, codSeccion) == true)
            {
                SqlConnection cn = con.conexion();
                SqlCommand sqlcmd = new SqlCommand("SPI_AC_PUESTO_SOCIO", cn);
                sqlcmd.Connection = cn;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                sqlcmd.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
                sqlcmd.Parameters.AddWithValue("@codSeccion", Convert.ToInt32(codSeccion));
                sqlcmd.Parameters.AddWithValue("@nroPuesto", Convert.ToInt32(nroPuesto));
                sqlcmd.Parameters.AddWithValue("@user", userReg);


                int var = sqlcmd.ExecuteNonQuery();
                if (var > 0)
                {
                    res = "OK";

                }


            }
            return res;



        }


        public bool InsertPuesto(string nroPuesto, string codSeccion)
        {

            bool result = false;
            SqlConnection cn = con.conexion();
            SqlCommand sqlcmd = new SqlCommand("SPI_PUESTO", cn);
            sqlcmd.Connection = cn;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            cn.Open();

            sqlcmd.Parameters.AddWithValue("@nroPuesto", Convert.ToInt32(nroPuesto));
            sqlcmd.Parameters.AddWithValue("@codSeccion", Convert.ToInt32(codSeccion));


            int var = sqlcmd.ExecuteNonQuery();
            if (var > 0)
            {
                result = true;

            }



            return result;

        }


        [WebMethod]
        public string[] getPuestosPorSocio(string accion, string Dni)
        {

            List<string> listResult = new List<string>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_LISTAR_SOCIO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@userName", Dni);


            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    string srt = dt.Rows[i]["NumeroPuesto"].ToString();



                    listResult.Add(srt);

                }


            }

            return listResult.ToArray();

        }

        [WebMethod]
        public string InsertPago(string accion, string codSocio, string codConcepto, string nroOpe, string codBanco, string observacion, string monto, string codPuesto, string fechaPago)
        {




            string res = "NO";
            int verificarpago = 0;

            verificarpago = this.ComprobarPagoExiste("5", codSocio, codConcepto, codPuesto);

            if (verificarpago <= 0)
            {
                try
                {

                    SqlConnection cn = con.conexion();
                    SqlCommand sqlcmd = new SqlCommand("SPI_AC_PAGOS", cn);
                    sqlcmd.Connection = cn;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    sqlcmd.Parameters.AddWithValue("@accion", accion);
                    sqlcmd.Parameters.AddWithValue("@codConcepto", Convert.ToInt32(codConcepto));
                    sqlcmd.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
                    sqlcmd.Parameters.AddWithValue("@nroOp", nroOpe);
                    sqlcmd.Parameters.AddWithValue("@codBanco", Convert.ToInt32(codBanco));
                    sqlcmd.Parameters.AddWithValue("@Observacion", observacion);
                    sqlcmd.Parameters.AddWithValue("@fechaPago", Convert.ToDateTime(fechaPago));
                    sqlcmd.Parameters.AddWithValue("@monto", Convert.ToDecimal(monto));
                    sqlcmd.Parameters.AddWithValue("@codPuesto", Convert.ToInt32(codPuesto));


                    int var = sqlcmd.ExecuteNonQuery();
                    if (var > 0)
                    {
                        res = "OK";

                    }

                    Socio s = GetSocioEmail("2", codSocio);
                    string concepto = GetConsultasPago("1", 0, Convert.ToInt32(codConcepto));
                    string currFecha = GetConsultasPago("3", 0, 0);
                    SentMail(s.ApellidoPat.ToUpper() + " " + s.ApellidoMat.ToUpper() + " " + s.Nombres.ToUpper(), s.Correo, concepto, monto, currFecha, nroOpe, codPuesto);

                }
                catch (Exception e)
                {

                    res = e.Message;
                }

            }
            else if (verificarpago > 0)
            {
                res = "PAGADO";

            }

            return res;




        }


        public int ComprobarPagoExiste(string accion, string codSocio, string codConcepto, string codNropuesto)
        {


            string res = "0";

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_CONSULTAS_PAGO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codConcepto", Convert.ToInt32(codConcepto));
            dap.SelectCommand.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
            dap.SelectCommand.Parameters.AddWithValue("@nroPuesto", Convert.ToInt32(codNropuesto));

            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                res = dt.Rows[0]["Pagos"].ToString();

            }

            return Convert.ToInt32(res);



        }




        public void SentMail(string nomUser, string correo, string concepto, string monto, string fecha, string nroOperacion, string nroPuesto)
        {

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("acmenconle.info@gmail.com", "probando123");

            String htmlmsj = "<h1 style='color: #5e9ca0;'>Confirmacion de Pago!</h1> </br> <h4 style='color: #2e6c80;'>Socio : " + nomUser + "</h4>" + " </br> <h4 style='color: #2e6c80;'>Monto : " + monto + "  soles</h4>" + " </br> <h4 style='color: #2e6c80;'>Fecha : " + fecha + "  </h4>" + " </br> <h4 style='color: #2e6c80;'>Concepto : " + concepto + "  </h4>" + " </br> <h4 style='color: #2e6c80;'>Nro.Operación : " + nroOperacion + "  </h4>" + " </br> <h4 style='color: #2e6c80;'>Nro.Puesto : " + nroPuesto + "  </h4>";

            MailMessage mm = new MailMessage("acmenconle.info@gmail.com", correo, "Confirmación de pago", htmlmsj);
            mm.IsBodyHtml = true;

            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);



        }

        [WebMethod]

        public string SentMailContacto(string nombre, string celular, string correo, string mensaje)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("acmenconle.info@gmail.com", "probando123");

            String htmlmsj = "<h1 style='color: #5e9ca0;'>Mensaje de contacto !</h1> </br> <h4 style='color: #2e6c80;'>Nombres : " + nombre + "</h4>" + " </br> <h4 style='color: #2e6c80;'>Celular : " + celular + " </h4>" + " </br> <h4 style='color: #2e6c80;'>Correo : " + correo + "  </h4>" + " </br> <h4 style='color: #2e6c80;'>Mensaje : " + mensaje + "  </h4>";


            MailMessage mm = new MailMessage("acmenconle.info@gmail.com", "acmenconle.info@gmail.com", "Mensaje de  contacto", htmlmsj);
            mm.IsBodyHtml = true;

            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);

            SentMailConfirmacion(correo, nombre);
            return "OK";

        }

        public string SentMailConfirmacion(string correo, string nombre)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("acmenconle.info@gmail.com", "probando123");

            String htmlmsj = "<h1 style='color: #5e9ca0;'>Hola " + nombre + "  tu mensaje fue enviado correctamente, en el transcurso del día nos estaremos comunicando contigo.!</h1> ";


            MailMessage mm = new MailMessage("acmenconle.info@gmail.com", correo, "Mensaje de confirmación", htmlmsj);
            mm.IsBodyHtml = true;

            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);

            return "OK";


        }

        [WebMethod]
        public string GetFechaMaxMinPago(string accion, string TipoFecha, string codSocio, string nroPuesto)
        {

            string result = "";

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_CONSULTAS_PAGO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@tipoFecha", TipoFecha);
            dap.SelectCommand.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
            dap.SelectCommand.Parameters.AddWithValue("@nroPuesto", Convert.ToInt32(nroPuesto));


            dap.Fill(dt);
            cn.Close();

            if (dt != null && dt.Rows.Count > 0)
            {


                result = dt.Rows[0]["result"].ToString();



            }



            return result;
        }

        public string GetConsultasPago(string accion, int codbanco, int codConcepto)
        {


            string result = "";

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_CONSULTAS_PAGO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codBanco", codbanco);
            dap.SelectCommand.Parameters.AddWithValue("@codConcepto", codConcepto);


            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {



                    result = dt.Rows[i]["result"].ToString();




                }


            }



            return result;


        }
        public Socio GetSocioEmail(string accion, string codSocio)
        {

            List<Socio> listSoc = new List<Socio>();
            Socio result = new Socio();
            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_LISTAR_SOCIO", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);


            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if ((dt.Rows[i]["CodigoSocio"].ToString()) == codSocio)
                    {
                        Socio sc = new Socio();
                        sc.CodSocio = Convert.ToInt32(dt.Rows[i]["CodigoSocio"].ToString());
                        sc.Dni = dt.Rows[i]["Dni"].ToString();
                        sc.Nombres = dt.Rows[i]["Nombres"].ToString();
                        sc.ApellidoPat = dt.Rows[i]["ApellidoPat"].ToString();
                        sc.ApellidoMat = dt.Rows[i]["ApellidoMat"].ToString();
                        sc.Puesto = dt.Rows[i]["Puesto"].ToString();
                        sc.Celular = dt.Rows[i]["Celular"].ToString();
                        sc.FechaRegistro = dt.Rows[i]["FechaRegistro"].ToString();
                        sc.Estado = dt.Rows[i]["Estado"].ToString();
                        sc.Correo = dt.Rows[i]["Correo"].ToString();
                        sc.TipoUsuario = dt.Rows[i]["Tipo"].ToString();

                        result = sc;
                        break;

                    }

                }


            }



            return result;

        }

        [WebMethod]
        public CPagos[] GetRepPagos(string accion, string codSocio, string nroPuesto)
        {

            List<CPagos> listpagos = new List<CPagos>();

            SqlConnection cn = con.conexion();
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SP_AC_REPORTE_PAGOS", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@accion", accion);
            dap.SelectCommand.Parameters.AddWithValue("@codSocio", Convert.ToInt32(codSocio));
            dap.SelectCommand.Parameters.AddWithValue("@nroPuesto", Convert.ToInt32(nroPuesto));


            dap.Fill(dt);
            cn.Close();

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    CPagos c = new CPagos();

                    c.Nombres = dt.Rows[i]["Nombres"].ToString();
                    c.FechaPago = dt.Rows[i]["FPago"].ToString();
                    c.Seccion = dt.Rows[i]["DescripSeccion"].ToString();
                    c.Monto = dt.Rows[i]["Monto"].ToString();
                    c.Banco = dt.Rows[i]["Banco"].ToString();
                    c.NroPuesto = dt.Rows[i]["nroPuesto"].ToString();
                    c.Estado = dt.Rows[i]["Estado"].ToString();

                    listpagos.Add(c);

                }


            }

            return listpagos.ToArray();




        }
        #endregion
    }
}
