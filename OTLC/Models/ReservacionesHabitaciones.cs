using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class ReservacionesHabitaciones
    {
        Conexion cx = new Conexion();
        Bitacora bita = new Bitacora();

        public int IdHabitacion { get; set; }
        public int IdHotel { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Destino { get; set; }
        public bool Certificado { get; set; }
        public bool Valido { get; set; }
        public bool DelNetCenter { get; set; }
        public bool DeAgencias { get; set; }
        public int Adultos { get; set; }
        public int Menores { get; set; }
        public int Capacidad { get; set; }
        public string Code { get; set; }
        public string TarifaB { get; set; }
        public string TarifaA { get; set; }


        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(ReservacionesHabitaciones);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(ReservacionesHabitaciones);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        private void Limpiar()
        {
            IdHabitacion = 0;
            IdHotel = 0;
            Codigo = "";
            Nombre = "";
            Descripcion = "";
            Destino = "";
            Certificado = false;
            Valido = false;
            DelNetCenter = false;
            DeAgencias = false;
            Adultos = 0;
            Menores = 0;
            Capacidad = 0;
            Code = "";
            TarifaB = "";
            TarifaA = "";
        }

        public void LeerHabitacion(int hotel, int habitacion )
        {
            Limpiar();
            string sql = "select*from ReservacionesHabitaciones where IdHotel=@IdHotel and IdHabitacion=@idHabitacion";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdHotel", SqlDbType.Int).Value = hotel;
                    comando.Parameters.Add("@idHabitacion", SqlDbType.Int).Value = habitacion;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                this[reader.GetName(i)] = reader.IsDBNull(i) ? cx.getNullValue(this[reader.GetName(i)]) : reader.GetValue(i);
                            }

                        }
                    }

                    con.Close();
                }

            }

        }

        public int ExisteRegistro(string campo, string valor)
        {
            int Existe = 0;
            string sql = "select IdHabitacion from ReservacionesHabitaciones where " + campo + " = '" + valor + "' and IdHotel=@IdHotel";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@IdHotel", SqlDbType.Int).Value = IdHotel;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Existe = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }

            return Existe;

        }

        private int MaxConsec()
        {
            int maximoConsec = 0;

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql = "select MAX(IdHabitacion) from ReservacionesHabitaciones";

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            maximoConsec = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                }
                con.Close();
            }

            return maximoConsec;
        }

        public void InsertHabitaciones()
        {
            string sql = "insert into ReservacionesHabitaciones" +
            "(IdHotel, Codigo, Nombre, Certificado, Valido, DelNetCenter, DeAgencias, Adultos,Menores, Capacidad, Code) values" +
            "(@idHotel, @Codigo, @Nombre, 0, 1, 0, 0, @Adultos, @Menores, @Capacidad, @Codigo)";

            using (SqlConnection conn = new SqlConnection(cx.cadenaConexion))
            {
                conn.Open();

                using (SqlCommand comando = new SqlCommand(sql, conn))
                {
                    comando.Parameters.Add("@idHotel", SqlDbType.Int).Value = IdHotel;
                    comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                    comando.Parameters.Add("@Adultos", SqlDbType.Int).Value = Adultos;
                    comando.Parameters.Add("@Menores", SqlDbType.Int).Value = Menores;
                    comando.Parameters.Add("@Capacidad", SqlDbType.Int).Value = Capacidad;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                conn.Close();
            }

            bita.RegistrarBitacora(100000, "ReservacionesHabitaciones","Registro Nuevo","I","", "IdHabitacion: " + MaxConsec() + ", Capacidad: "+Capacidad);
        }

        public void ModificaHabitacion(string campo, string anterior, string nuevo)
        {
            string sql = nuevo == "" ? "UPDATE ReservacionesHabitaciones set " + campo + "=null  where idHotel = @idHotel and IdHabitacion=@idHabitacion"
                                     : "UPDATE ReservacionesHabitaciones set " + campo + "= '" + nuevo + "' where idHotel = @idHotel and IdHabitacion=@idHabitacion";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@idHotel", SqlDbType.Int).Value = IdHotel;
                    comando.Parameters.Add("@IdHabitacion", SqlDbType.Int).Value = IdHabitacion;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }

            bita.RegistrarBitacora(100000, "ReservacionesHabitaciones", campo + " (IdHabitacion: "+ IdHabitacion +")", "U", anterior, nuevo);
        }


    }
}
