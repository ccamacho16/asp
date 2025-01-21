using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Collections;



namespace SGCC.Clases
{
    public class ConexBD
    {
        String connectionString;
        SqlConnection myConnection;
        SqlDataReader myReader;

        //Conexion con la Base de Datos.
        public void conectar()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["conexsgcc"].ConnectionString;
            myConnection = new SqlConnection(connectionString);
            myConnection.Open();
        }
        //Finaliza la conexion con la Base de Datos.
        public void desconectar()
        {
            myConnection.Close();
        }
        //Devuelve la conexion existente con la Base de Datos
        public SqlConnection getConexion()
        {
            return myConnection;
        }
        public String InsertarCliente(String ci, String ext, String nombre, String dirdom, String dirneg, String telf, String tipo, String rubro, String estado)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spInsertarCliente", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;
                cmd.Parameters.Add("@ext", SqlDbType.VarChar).Value = ext;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@dirdom", SqlDbType.VarChar).Value = dirdom;
                cmd.Parameters.Add("@dirneg", SqlDbType.VarChar).Value = dirneg;
                cmd.Parameters.Add("@telf", SqlDbType.VarChar).Value = telf;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                cmd.Parameters.Add("@rubro", SqlDbType.VarChar).Value = rubro;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;  

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<String> ConsultarCliente(String ci)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaCliente", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;

                myReader = cmd.ExecuteReader();                
                var consultas = new List<string>();

                while (myReader.Read())
                {
                    consultas.Add(myReader["ci"].ToString());
                    consultas.Add(myReader["ext"].ToString());
                    consultas.Add(myReader["nombre"].ToString());
                    consultas.Add(myReader["dirdom"].ToString());
                    consultas.Add(myReader["dirneg"].ToString());
                    consultas.Add(myReader["telf"].ToString());
                    consultas.Add(myReader["tipo"].ToString());
                    consultas.Add(myReader["rubro"].ToString());
                }

                cmd.Dispose();
                myReader.Dispose();              

                this.desconectar();
                return consultas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public String ActualizarCliente(String ci, String ext, String nombre, String dirdom, String dirneg, String telf, String tipo, String rubro)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarCliente", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;
                cmd.Parameters.Add("@ext", SqlDbType.VarChar).Value = ext;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@dirdom", SqlDbType.VarChar).Value = dirdom;
                cmd.Parameters.Add("@dirneg", SqlDbType.VarChar).Value = dirneg;
                cmd.Parameters.Add("@telf", SqlDbType.VarChar).Value = telf;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                cmd.Parameters.Add("@rubro", SqlDbType.VarChar).Value = rubro;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<String> ConsultarGarante(String ci)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaGarante", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;

                myReader = cmd.ExecuteReader();
                var consultas = new List<string>();

                while (myReader.Read())
                {
                    consultas.Add(myReader["ci"].ToString());
                    consultas.Add(myReader["ext"].ToString());
                    consultas.Add(myReader["nombre"].ToString());
                    consultas.Add(myReader["dirdom"].ToString());
                    consultas.Add(myReader["telf"].ToString());
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return consultas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public String InsertarGarante(String ci, String ext, String nombre, String dirdom, String telf)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spInsertarGarante", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;
                cmd.Parameters.Add("@ext", SqlDbType.VarChar).Value = ext;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@dirdom", SqlDbType.VarChar).Value = dirdom;
                cmd.Parameters.Add("@telf", SqlDbType.VarChar).Value = telf;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String ActualizarGarante(String ci, String ext, String nombre, String dirdom, String telf)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarGarante", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;
                cmd.Parameters.Add("@ext", SqlDbType.VarChar).Value = ext;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@dirdom", SqlDbType.VarChar).Value = dirdom;
                cmd.Parameters.Add("@telf", SqlDbType.VarChar).Value = telf;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String GetIdOfiCred()
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spGetNumOfiCredito", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                myReader = cmd.ExecuteReader();
                String id = "";

                while (myReader.Read())
                {
                    id = myReader["numero"].ToString();
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<String> ConsultarOfiCred(int id)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaOfiCredito", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                myReader = cmd.ExecuteReader();
                var consultas = new List<string>();

                while (myReader.Read())
                {
                    consultas.Add(myReader["id"].ToString());
                    consultas.Add(myReader["ci"].ToString());
                    consultas.Add(myReader["ext"].ToString());
                    consultas.Add(myReader["nombre"].ToString());
                    consultas.Add(myReader["dirdom"].ToString());
                    consultas.Add(myReader["telf"].ToString());
                    consultas.Add(myReader["estado"].ToString());
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return consultas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String InsertarOfiCredito(int ci, String ext, String nombre, String dirdom, String telf, bool estado)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spInsertarOfiCred", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.Int).Value = ci;
                cmd.Parameters.Add("@ext", SqlDbType.VarChar).Value = ext;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@dirdom", SqlDbType.VarChar).Value = dirdom;
                cmd.Parameters.Add("@telf", SqlDbType.VarChar).Value = telf;
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String ActualizarOfiCredito(int id, int ci, String ext, String nombre, String dirdom, String telf, bool estado)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarOfiCred", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@ci", SqlDbType.Int).Value = ci;
                cmd.Parameters.Add("@ext", SqlDbType.VarChar).Value = ext;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@dirdom", SqlDbType.VarChar).Value = dirdom;
                cmd.Parameters.Add("@telf", SqlDbType.VarChar).Value = telf;
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Hashtable TodosOfiCred()
        {
            try
            {

                Hashtable h = new Hashtable();

                this.conectar();

                SqlCommand cmd = new SqlCommand("spTodosOfiCred", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                myReader = cmd.ExecuteReader();                

                while (myReader.Read())
                {
                    h.Add(myReader["id"].ToString(), myReader["nombre"].ToString());
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return h;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public String InsertCredito(String codcli, DateTime fecha, String codgar, String refper, String reflab, int oficre, String nomoficre, String forpago, int monto, int plazo, int nrocuota, String garantia, int interes, int gasadm, String usuario, DataTable dt, String tipocredito, String comentario, String dato1, String dato2){
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spInsertCabCredito", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@gestion", SqlDbType.Int).Value = DateTime.Now.Year;
                cmd.Parameters.Add("@mes", SqlDbType.Int).Value = DateTime.Now.Month;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@codcli", SqlDbType.VarChar).Value = codcli;
                cmd.Parameters.Add("@codgar", SqlDbType.VarChar).Value = codgar;
                cmd.Parameters.Add("@refper", SqlDbType.VarChar).Value = refper;
                cmd.Parameters.Add("@reflab", SqlDbType.VarChar).Value = reflab;
                cmd.Parameters.Add("@oficre", SqlDbType.Int).Value = oficre;
                cmd.Parameters.Add("@nomoficre", SqlDbType.VarChar).Value = nomoficre;
                cmd.Parameters.Add("@forpago", SqlDbType.VarChar).Value = forpago;
                cmd.Parameters.Add("@monto", SqlDbType.Int).Value = monto;
                cmd.Parameters.Add("@plazo", SqlDbType.Int).Value = plazo;                
                cmd.Parameters.Add("@nrocuota", SqlDbType.Int).Value = nrocuota;
                cmd.Parameters.Add("@garantia", SqlDbType.VarChar).Value = garantia;
                cmd.Parameters.Add("@interes", SqlDbType.Int).Value = interes;
                cmd.Parameters.Add("@gasadm", SqlDbType.Int).Value = gasadm;
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@tipocredito", SqlDbType.VarChar).Value = tipocredito;
                cmd.Parameters.Add("@comentario", SqlDbType.VarChar).Value = comentario;
                cmd.Parameters.Add("@dato1", SqlDbType.VarChar).Value = dato1;
                cmd.Parameters.Add("@dato2", SqlDbType.VarChar).Value = dato2;
                cmd.Parameters.Add("@dato3", SqlDbType.VarChar).Value = "";

                myReader = cmd.ExecuteReader();

                myReader.Read();
                int id = int.Parse(myReader["idcab"].ToString());

                myReader.Dispose();

                foreach (DataRow row in dt.Rows){
                    this.insertarDetalle(myConnection, id, row);
                }

                this.desconectar();
                return "" + id;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public void insertarDetalle(SqlConnection myConnectionpaso, int idcab, DataRow row)
        {
            SqlCommand cmd = new SqlCommand("spInsertDetCredito", myConnectionpaso);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;
            cmd.Parameters.Add("@nro", SqlDbType.Int).Value = int.Parse(row[0].ToString());
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = Convert.ToDateTime(row[1].ToString());
            cmd.Parameters.Add("@capital", SqlDbType.Int).Value = int.Parse(row[2].ToString());
            cmd.Parameters.Add("@interes", SqlDbType.Int).Value = int.Parse(row[3].ToString());
            cmd.Parameters.Add("@saldocap", SqlDbType.Int).Value = int.Parse(row[4].ToString());
            cmd.Parameters.Add("@total", SqlDbType.Int).Value = int.Parse(row[5].ToString());


            cmd.ExecuteNonQuery();
        }

        public List<String> ConsultarDatosCredito(int codcre)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaDatosCredito", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@codcre", SqlDbType.Int).Value = codcre;

                myReader = cmd.ExecuteReader();
                var consultas = new List<string>();

                while (myReader.Read())
                {
                    consultas.Add(myReader["codcli"].ToString());
                    consultas.Add(myReader["nombre"].ToString());
                    consultas.Add(myReader["fecha"].ToString());
                    consultas.Add(myReader["monto"].ToString());
                    consultas.Add(myReader["forpago"].ToString());
                    consultas.Add(myReader["nrocuota"].ToString());
                    consultas.Add(myReader["Estado"].ToString());
                    consultas.Add(myReader["garantia"].ToString());
                    consultas.Add(myReader["plazo"].ToString());
                    consultas.Add(myReader["interes"].ToString());
                    //9
                    consultas.Add(myReader["codgar"].ToString());
                    consultas.Add(myReader["refper"].ToString());
                    consultas.Add(myReader["reflab"].ToString());
                    consultas.Add(myReader["oficre"].ToString());
                    consultas.Add(myReader["nomoficre"].ToString());
                    consultas.Add(myReader["dato2"].ToString());
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return consultas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public String ActualizarAnulCredito(int codcre)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarAnulCredito", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@codcre", SqlDbType.Int).Value = codcre;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String ConsultarUsuario(String user, String pass)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaUsuario", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = pass;

                myReader = cmd.ExecuteReader();
                String tipo = "";

                if (myReader.HasRows    )
                {
                    myReader.Read();
                    tipo = myReader["tipo"].ToString();
    
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return tipo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ConsultaCabCobranza(String ci)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaCabCobranza", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;

                DataTable dt = new DataTable();
                dt.Columns.Add("codcli", typeof(string));
                dt.Columns.Add("nombre", typeof(string));
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("dato", typeof(string));


                myReader = cmd.ExecuteReader();


                while (myReader.Read())
                {
                    
                    String codcli = myReader["codcli"].ToString();
                    String nombre = myReader["nombre"].ToString();
                    int id = int.Parse(myReader["ID"].ToString());
                    String dato = myReader["dato"].ToString();
                    dt.Rows.Add(codcli, nombre, id, dato);                    
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ConsultaPlaPagoCredito(int idcre)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaPlanPagoCredito", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcre", SqlDbType.Int).Value = idcre;

                DataTable dt = new DataTable();

                dt.Columns.Add("nro", typeof(string));
                dt.Columns.Add("fecha", typeof(string));
                dt.Columns.Add("capital", typeof(string));
                dt.Columns.Add("interes", typeof(string));
                dt.Columns.Add("saldocapital", typeof(string));
                dt.Columns.Add("totalbs", typeof(string));
                dt.Columns.Add("estado", typeof(string));
                //dt.Columns.Add("fechapago", typeof(string));


                myReader = cmd.ExecuteReader();


                while (myReader.Read())
                {

                    String nro = myReader["nro"].ToString();
                    String fecha = myReader["fecha"].ToString();
                    String capital = myReader["capital"].ToString();
                    String interes = myReader["interes"].ToString();
                    String saldocap = myReader["saldocap"].ToString();
                    String total = myReader["total"].ToString();
                    String pagado = myReader["pagado"].ToString();
                    if (pagado == "True"){
                        pagado = "Pagado";
                    }else{
                        pagado = "";
                    }


                    dt.Rows.Add(nro, fecha, capital, interes, saldocap, total, pagado);
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String ActualizarPago(int idcab, int nro, bool pagado, DateTime fecha, int mora, String usuario)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarPago", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;
                cmd.Parameters.Add("@nro", SqlDbType.Int).Value = nro;
                cmd.Parameters.Add("@pagado", SqlDbType.Bit).Value = pagado;
                cmd.Parameters.Add("@fechapago", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@mora", SqlDbType.Int).Value = mora;
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                cmd.ExecuteNonQuery();

                this.desconectar();

                return "";
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String ActualizarPagoTodo(int idcab, int nro, bool pagado, DateTime fecha, int saldocapital, int mora, int interes, String usuario)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarPagoTodo", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;
                cmd.Parameters.Add("@nro", SqlDbType.Int).Value = nro;
                cmd.Parameters.Add("@pagado", SqlDbType.Bit).Value = pagado;
                cmd.Parameters.Add("@fechapago", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@saldocap", SqlDbType.Int).Value = saldocapital;
                cmd.Parameters.Add("@mora", SqlDbType.Int).Value = mora;
                cmd.Parameters.Add("@interes", SqlDbType.Int).Value = interes;
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                cmd.ExecuteNonQuery();

                this.desconectar();

                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //---------------------------------
        //---------------------------------
        public void ActualizarCreditoPagado(int idcab)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarCreditoPagado", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;

                cmd.ExecuteNonQuery();

                this.desconectar();

            }
            catch (Exception ex)
            {

            }
        }
        public String GenerarBackup(String dir, String nombre)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spBackup", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@dir", SqlDbType.VarChar).Value = dir;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;

                cmd.ExecuteNonQuery();

                this.desconectar();

                return "";
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public SqlDataAdapter rpPlanPagoCredito(int idcab, String estado)
        {
            try
            {
                this.conectar();
                SqlCommand cmd = new SqlCommand("sprPlanPagoCredito", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idcab;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataAdapter rpComprobantePrestamo(int idcab)
        {
            try
            {
                this.conectar();
                SqlCommand cmd = new SqlCommand("sprComprobantePrestamo", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;                

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public String rpConsultaFechaMaxima(int idcab) {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprConsultaFechaMaxima", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;

                myReader = cmd.ExecuteReader();
                String fecha = "";

                while (myReader.Read())
                {
                    fecha = myReader["fecha"].ToString();
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return fecha;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<String> ConsultaDatosCreditoDes(int codcre)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaDatosCreditoDes", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = codcre;

                myReader = cmd.ExecuteReader();
                var consultas = new List<string>();

                while (myReader.Read())
                {
                    consultas.Add(myReader["codcli"].ToString());
                    consultas.Add(myReader["nombre"].ToString());
                    consultas.Add(myReader["fecha"].ToString());
                    consultas.Add(myReader["monto"].ToString());
                    consultas.Add(myReader["forpago"].ToString());
                    consultas.Add(myReader["nrocuota"].ToString());
                    consultas.Add(myReader["Estado"].ToString());
                    consultas.Add(myReader["garantia"].ToString());
                    consultas.Add(myReader["fechades"].ToString());
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return consultas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<String> ConsultaDatosCreditoDesR(int codcre)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaDatosCreditoDesR", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = codcre;

                myReader = cmd.ExecuteReader();
                var consultas = new List<string>();

                while (myReader.Read())
                {
                    consultas.Add(myReader["codcli"].ToString());
                    consultas.Add(myReader["nombre"].ToString());
                    consultas.Add(myReader["fecha"].ToString());
                    consultas.Add(myReader["monto"].ToString());
                    consultas.Add(myReader["forpago"].ToString());
                    consultas.Add(myReader["nrocuota"].ToString());
                    consultas.Add(myReader["Estado"].ToString());
                    consultas.Add(myReader["garantia"].ToString());
                    consultas.Add(myReader["fechades"].ToString());
                    consultas.Add(myReader["montoref"].ToString());
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return consultas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String ActualizarFechaDes(int codcre, DateTime fecha)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarFechaDes", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@codcre", SqlDbType.Int).Value = codcre;
                cmd.Parameters.Add("@fechades", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public SqlDataAdapter rpConsultaComprobantePagoCuotas(int idcre, DateTime fecha, String usuario)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprComprobantePagoCuotas", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcre", SqlDbType.Int).Value = idcre;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public String SiguientePago(int idcab)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spSiguientePago", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;

                myReader = cmd.ExecuteReader();
                String fecha = "";
                String total = "";
                String r = "";
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        fecha = myReader["fecha"].ToString();
                        total = myReader["total"].ToString();
                    }
                    r = total + "Bs.  " + fecha.Substring(0, 10);
                }
                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return r;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Hashtable ConsultaDatosMasterEntidad(String entidad)
        {
            try
            {

                Hashtable h = new Hashtable();

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaEntidad", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@entidad", SqlDbType.VarChar).Value = entidad;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = "%";

                myReader = cmd.ExecuteReader();
                String aux="";
                while (myReader.Read())
                {
                    String tipo = myReader["Tipo"].ToString();
                    if (tipo != aux){
                        h.Add(tipo, myReader["Valor1"].ToString());
                        aux = tipo;
                    }
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return h;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataAdapter rpPagosRangoFecha(String fecha1, String fecha2)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprPagosRangoFecha", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataAdapter rpDesembolsoRangoFecha(String fecha1, String fecha2, String opcion)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprDesembolsoRangoFecha", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;
                cmd.Parameters.Add("@opcion", SqlDbType.VarChar).Value = opcion;


                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter rpConsultaMoraClientes(String fecha, String oficre)
        {
            try
            {
                Console.WriteLine("1");
                String vmora = this.ConsultaDatosEntidadTipo("VALORES","MULTA_MORA");

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprConsultaMoraClientes", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                
                //antes de vmora, estaba fijo el valor 2.5
                cmd.Parameters.Add("@vmora", SqlDbType.Decimal).Value = vmora;
                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha;
                cmd.Parameters.Add("@oficre", SqlDbType.VarChar).Value = oficre;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String ConsultaDatosEntidadTipo(String entidad, String tipo)
        {
            try
            {
                

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaEntidad", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@entidad", SqlDbType.VarChar).Value = entidad;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;

                myReader = cmd.ExecuteReader();

                String valor1 = "";

                while (myReader.Read())
                {
                    valor1 = myReader["valor1"].ToString();
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();

                return valor1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<String> ConsultaValor_EntidadTipo(String entidad, String tipo)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaEntidad", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@entidad", SqlDbType.VarChar).Value = entidad;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;

                myReader = cmd.ExecuteReader();
                var consultas = new List<string>();

                while (myReader.Read())
                {
                    consultas.Add(myReader["Valor1"].ToString());
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return consultas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public String rpDetalleCreditoCSV(String fecha1, String fecha2){
            try
            {
                /*conexion.conectar();
                SqlConnection con = conexion.getConexion();*/
                this.conectar();
                string csv = "";
                //using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCliente"))
                using (SqlCommand cmd = new SqlCommand("sprDetalleCreditoCSV", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                    cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = myConnection;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Build the CSV file data as a Comma separated string.
                            csv = string.Empty;

                            foreach (DataColumn column in dt.Columns)
                            {
                                //Add the Header row for CSV file.
                                csv += column.ColumnName + ';';
                            }

                            //Add new line.
                            csv += "\r\n";

                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    //Add the Data rows.
                                    csv += row[column.ColumnName].ToString() + ';';
                                }

                                //Add new line.
                                csv += "\r\n";
                            }

                            //Download the CSV file.
                            /*Response.Clear();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
                            Response.Charset = "";
                            Response.ContentType = "application/text";
                            Response.Output.Write(csv);
                            Response.Flush();
                            Response.End();*/
                        }
                    }
                }
                this.desconectar();
                return csv;
            }
            catch (Exception ex)
            {
                return null;
            }
            

        }

        public SqlDataAdapter rpConsultaDatosCliente(String ci)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaCliente", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter rpPagosProgFecha(String fechaIni, String fechaFin)
        {
            try
            {                
                this.conectar();

                SqlCommand cmd = new SqlCommand("sprPagosProgFecha", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fechaIni;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fechaFin;


                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int DiasFeriados(String fecha1, String fecha2)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spDiasFeriados", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;

                myReader = cmd.ExecuteReader();
                int dias = 0;

                DateTime fechaprog = Convert.ToDateTime(fecha1);

                while (myReader.Read()){
                    DateTime fecha = Convert.ToDateTime(myReader["feriados"].ToString());
                    if (fecha == fechaprog)
                    {
                        if ((int)fecha.DayOfWeek == 6){
                            dias++;
                        }

                        fechaprog = fechaprog.AddDays(1);

                        dias++;
                    }

                }

                myReader.Dispose();

                this.desconectar();

                return dias;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public SqlDataAdapter rpSaldoCapital(String fecha1, String fecha2)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprReporteSaldoCapital", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter rpDesembolsoOfialCre(String fecha1, String fecha2)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprDesembolsoOficialCre", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter rpDatosCredito(String credito)
        {
            try
            {                
                this.conectar();

                SqlCommand cmd = new SqlCommand("sprDatosCredito", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                //antes de vmora, estaba fijo el valor 2.5
                
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(credito);

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String InsertarEgresos(DateTime fecha, String tipo, String descrip, String debe, String haber)
        {
            try
            {
                this.conectar();

                SqlCommand cmd = new SqlCommand("spInsertarEgresos", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                cmd.Parameters.Add("@descrip", SqlDbType.VarChar).Value = descrip;
                cmd.Parameters.Add("@debe", SqlDbType.Decimal).Value = debe;
//                haber = haber.Replace(".",",");
                cmd.Parameters.Add("@haber", SqlDbType.Decimal).Value = Convert.ToDecimal(haber);

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String InsertarIngresos(DateTime fecha, String tipo, String descrip, String debe, String haber)
        {
            try
            {
                this.conectar();

                SqlCommand cmd = new SqlCommand("spInsertarIngresos", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                cmd.Parameters.Add("@descrip", SqlDbType.VarChar).Value = descrip;
                cmd.Parameters.Add("@debe", SqlDbType.Decimal).Value = Convert.ToDecimal(debe);
                cmd.Parameters.Add("@haber", SqlDbType.Decimal).Value = haber;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SqlDataAdapter rpLibroDiario(String fecha1, String fecha2, String  saldoant)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprLibroDiario", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;
                cmd.Parameters.Add("@saldoant", SqlDbType.Decimal).Value = saldoant;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String GetSaldoAnterior(String fecha)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spGetSaldoAnterior", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;


                myReader = cmd.ExecuteReader();

                myReader.Read();

                String saldoant = myReader["saldo"].ToString();

                myReader.Dispose();

                this.desconectar();

                return saldoant;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String GetSaldoAnteriorFC(String fecha)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spGetSaldoAnteriorFC", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;


                myReader = cmd.ExecuteReader();

                myReader.Read();

                String saldoant = myReader["saldo"].ToString();

                myReader.Dispose();

                this.desconectar();

                return saldoant;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter rpFlujoCaja(String fecha1, String fecha2, String saldoant)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprFlujoCaja", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;
                cmd.Parameters.Add("@saldoant", SqlDbType.Decimal).Value = saldoant;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter rpExtractoPagos(int idcab)
        {
            try
            {
                this.conectar();
                SqlCommand cmd = new SqlCommand("sprExtractoPagos", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idcab;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ConsultaClientesMoraIni(String fecha)
        {
            try
            {
                String vmora = this.ConsultaDatosEntidadTipo("VALORES", "MULTA_MORA");

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprConsultaMoraClienteIni", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@vmora", SqlDbType.Decimal).Value = vmora;
                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha;
                

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("codcli", typeof(string));
                dt.Columns.Add("ext", typeof(string));
                dt.Columns.Add("nombre", typeof(string));
                dt.Columns.Add("telf", typeof(string));
                dt.Columns.Add("fecha", typeof(string));
                dt.Columns.Add("oficre", typeof(string));
                dt.Columns.Add("cuota", typeof(string));
                dt.Columns.Add("diasretraso", typeof(int));
                dt.Columns.Add("capital", typeof(int));
                dt.Columns.Add("interes", typeof(int));
                dt.Columns.Add("mora", typeof(int));
                dt.Columns.Add("total", typeof(int));


                myReader = cmd.ExecuteReader();


                while (myReader.Read())
                {

                    String id = myReader["ID"].ToString();
                    String codcli = myReader["codcli"].ToString();                    
                    String ext = myReader["ext"].ToString();
                    String nombre = myReader["nombre"].ToString();
                    String telf = myReader["telf"].ToString();
                    String vfecha = myReader["fecha"].ToString();
                    String oficre = myReader["oficre"].ToString();
                    String cuota = myReader["cuota"].ToString();
                    int diasretraso = Int32.Parse(myReader["diasretraso"].ToString());
                    int capital = Int32.Parse(myReader["capital"].ToString());
                    int interes = Int32.Parse(myReader["interes"].ToString());
                    int mora = Int32.Parse(myReader["mora"].ToString());
                    int total = Int32.Parse(myReader["total"].ToString());



                    dt.Rows.Add(id, codcli, ext, nombre, telf, vfecha, oficre, cuota, diasretraso, capital, interes, mora, total);
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable PagosProgFechaIni(String fecha1, String fecha2)
        {
            try
            {
                this.conectar();

                SqlCommand cmd = new SqlCommand("sprPagosProgFechaIni", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;


                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("codcli", typeof(string));
                dt.Columns.Add("ext", typeof(string));
                dt.Columns.Add("nombre", typeof(string));
                dt.Columns.Add("telf", typeof(string));
                dt.Columns.Add("fechaprog", typeof(string));
                dt.Columns.Add("oficre", typeof(string));                
                dt.Columns.Add("forpago", typeof(string));
                dt.Columns.Add("cuota", typeof(string));
                dt.Columns.Add("capital", typeof(int));
                dt.Columns.Add("interes", typeof(int));
                dt.Columns.Add("total", typeof(int));
                dt.Columns.Add("estado", typeof(string));


                myReader = cmd.ExecuteReader();


                while (myReader.Read())
                {

                    String id = myReader["ID"].ToString();
                    String codcli = myReader["codcli"].ToString();
                    String ext = myReader["ext"].ToString();
                    String nombre = myReader["nombre"].ToString();
                    String telf = myReader["telf"].ToString();
                    String fechaprog = myReader["fechaprog"].ToString();
                    String oficre = myReader["oficre"].ToString();
                    String forpago = myReader["forpago"].ToString();
                    String cuota = myReader["cuota"].ToString();
                    int capital = Int32.Parse(myReader["capital"].ToString());
                    int interes = Int32.Parse(myReader["interes"].ToString());
                    int total = Int32.Parse(myReader["total"].ToString());
                    String estado = myReader["estado"].ToString();

                    dt.Rows.Add(id, codcli, ext, nombre, telf, fechaprog, oficre, forpago,cuota, capital, interes, total, estado);
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String BorrarDetCreditoPaso(String usuario)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spBorrarDetCredPaso", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SqlDataAdapter rpConsultaMoraHistorico(String ci)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprConsultaMoraHistorico", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@codcli", SqlDbType.VarChar).Value = ci;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter rpEstadoPlanPagoCre(int idcab)
        {
            try
            {
                this.conectar();
                SqlCommand cmd = new SqlCommand("sprEstadoPlanPagoCre", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idcab;               

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int GetSaldoCapital(int idcab)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spGetSaldoCapital", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;


                myReader = cmd.ExecuteReader();

                myReader.Read();

                int saldoant =  Int32.Parse( myReader["saldocap"].ToString() );

                myReader.Dispose();

                this.desconectar();

                return saldoant;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetSumInteresSaldo(int idcab)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spGetSumInteresSaldo", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;


                myReader = cmd.ExecuteReader();

                myReader.Read();

                int suminteres = Int32.Parse(myReader["suminteres"].ToString());

                myReader.Dispose();

                this.desconectar();

                return suminteres;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public String ActualizaPagadoCreAlt(DateTime fecha, int idcab, int idcabnuevo, int capital, int adicional, String tipo, int gasadm)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizaPagadoCreAlt", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fechapago", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = idcab;
                cmd.Parameters.Add("@idcabnuevo", SqlDbType.Int).Value = idcabnuevo;
                cmd.Parameters.Add("@capital", SqlDbType.Int).Value = capital;
                cmd.Parameters.Add("@adicional", SqlDbType.Int).Value = adicional;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                cmd.Parameters.Add("@gasadm", SqlDbType.Int).Value = gasadm;

                cmd.ExecuteNonQuery();

                this.desconectar();

                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SqlDataAdapter rpPorcentajePagosCred()
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spPorcentajePagosCred", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String InyectarCapital(DateTime fecha, String tipo, String descrip, String debe, String haber)
        {
            try
            {
                this.conectar();

                SqlCommand cmd = new SqlCommand("spInyectarCapital", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                cmd.Parameters.Add("@descrip", SqlDbType.VarChar).Value = descrip;
                cmd.Parameters.Add("@debe", SqlDbType.Decimal).Value = Convert.ToDecimal(debe);
                cmd.Parameters.Add("@haber", SqlDbType.Decimal).Value = haber;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SqlDataAdapter rpOtrosIngresosEgresos(String fecha1, String fecha2, String tipo)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprOtrosIngresosEgresos", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha1;
                cmd.Parameters.Add("@date2", SqlDbType.Date).Value = fecha2;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;


                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable graDesembolsoOficial()
        {
            try
            {

                this.conectar();


                DataTable tb = new DataTable();
                SqlCommand cmd = new SqlCommand("spGraDesembolsoOficial", myConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //DataSet ds = new DataSet();

                //da.Fill(ds);
                da.Fill(tb);

                cmd.Dispose();
                da.Dispose();
                
                this.desconectar();
                return tb;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String insertarCaja(DateTime fecha, String tipo, String descrip, String monto, String usuario)
        {
            try
            {
                this.conectar();

                SqlCommand cmd = new SqlCommand("spInsertarCaja", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                cmd.Parameters.Add("@descrip", SqlDbType.VarChar).Value = descrip;
                cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = Convert.ToDecimal(monto);
                //                haber = haber.Replace(".",",");
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    

        public DataTable ConsultaDatosCaja(DateTime fecha, String tipo)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaCaja", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;


                DataTable dt = new DataTable();

                dt.Columns.Add("Concepto", typeof(string));
                dt.Columns.Add("Monto", typeof(string));

                myReader = cmd.ExecuteReader();
            
                while (myReader.Read())
                {

                    String concepto = myReader["descrip"].ToString();
                    String monto = myReader["monto"].ToString();


                    dt.Rows.Add(concepto, monto);
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String ActualizaTotalFlujoCaja(DateTime fecha)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizaTotalFlujoCaja", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.ToString("dd-MM-yyyy");

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SqlDataAdapter rpConsultaCaja(String fecha)
        {
            try
            {
                
                this.conectar();

                SqlCommand cmd = new SqlCommand("sprConsultaCaja", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String ActualizarCreditoCastigado(int codcre)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarCreditoCastigado", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = codcre;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SqlDataAdapter rpConsultaMoraCastigados(String fecha)
        {
            try
            {
                String vmora = this.ConsultaDatosEntidadTipo("VALORES", "MULTA_MORA");

                this.conectar();

                SqlCommand cmd = new SqlCommand("sprConsultaMoraCastigados", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                //antes de vmora, estaba fijo el valor 2.5
                cmd.Parameters.Add("@vmora", SqlDbType.Decimal).Value = vmora;
                cmd.Parameters.Add("@date1", SqlDbType.Date).Value = fecha;

                cmd.ExecuteNonQuery();

                SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

                this.desconectar();

                return sdadapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<String> ConsultarClienteCastigo(String ci)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaClienteCastigo", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;

                myReader = cmd.ExecuteReader();
                var consultas = new List<string>();

                while (myReader.Read())
                {
                    consultas.Add(myReader["ci"].ToString());
                    consultas.Add(myReader["ext"].ToString());
                    consultas.Add(myReader["nombre"].ToString());
                    consultas.Add(myReader["dirdom"].ToString());
                    consultas.Add(myReader["dirneg"].ToString());
                    consultas.Add(myReader["telf"].ToString());
                    consultas.Add(myReader["tipo"].ToString());
                    consultas.Add(myReader["rubro"].ToString());
                    consultas.Add(myReader["estado"].ToString());
                }

                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();
                return consultas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String ActualizarClienteEstado(String ci, String estado)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarClienteEstado", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool ConsultarEsClienteCastigado(String ci)
        {
      

                this.conectar();

                SqlCommand cmd = new SqlCommand("spConsultaEsClienteCastigado", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ci", SqlDbType.VarChar).Value = ci;

                myReader = cmd.ExecuteReader();

                bool sw;

                if (myReader.Read())
                {
                    sw = true;
                }
                else {
                    sw = false;
                }   


                cmd.Dispose();
                myReader.Dispose();

                this.desconectar();

                return sw;
        }

        public int GetCapitalNroCuota(int codcre, int nrocuota)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spGetCapitalNroCuota", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = codcre;
                cmd.Parameters.Add("@cuota", SqlDbType.Int).Value = nrocuota;


                myReader = cmd.ExecuteReader();

                myReader.Read();

                int saldoant = Int32.Parse(myReader["capital"].ToString());

                myReader.Dispose();

                this.desconectar();

                return saldoant;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetInteresNroCuota(int codcre, int nrocuota)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spGetInteresNroCuota", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = codcre;
                cmd.Parameters.Add("@cuota", SqlDbType.Int).Value = nrocuota;


                myReader = cmd.ExecuteReader();

                myReader.Read();

                int saldoant = Int32.Parse(myReader["interes"].ToString());

                myReader.Dispose();

                this.desconectar();

                return saldoant;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public String ActualizarCapitalCuota(int codcre, int nrocuota, int monto)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarCapitalCuota", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = codcre;
                cmd.Parameters.Add("@cuota", SqlDbType.Int).Value = nrocuota;
                cmd.Parameters.Add("@monto", SqlDbType.Int).Value = monto;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String ActualizarInteresCuota(int codcre, int nrocuota, int monto)
        {
            try
            {

                this.conectar();

                SqlCommand cmd = new SqlCommand("spActualizarInteresCuota", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idcab", SqlDbType.Int).Value = codcre;
                cmd.Parameters.Add("@cuota", SqlDbType.Int).Value = nrocuota;
                cmd.Parameters.Add("@monto", SqlDbType.Int).Value = monto;

                cmd.ExecuteNonQuery();

                this.desconectar();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
