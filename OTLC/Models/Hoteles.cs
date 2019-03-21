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
    class Hoteles
    {
        Conexion cx = new Conexion();
        Bitacora bita = new Bitacora();

        public int idHotel { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int idSalaVta { get; set; }
        public string Destino { get; set; }
        public string DirListaTrabajo { get; set; }
        public string ArchivoLista { get; set; }
        public string Delsistema { get; set; }
        public int idUsuarioAlt { get; set; }
        public DateTime Fechoralt { get; set; }
        public int ContactoMinimo { get; set; }
        public int ContactoMinimoPR { get; set; }
        public int ContactoMinimoSG { get; set; }
        public int InvitadosMinimos { get; set; }
        public int InvitadosMinimosBono { get; set; }
        public int ShowMinimo50 { get; set; }
        public int ShowMinimo { get; set; }
        public int ShowMinimoBono { get; set; }
        public int PremMinimo50 { get; set; }
        public int PremMinimo { get; set; }
        public double PorSelfGenMinimo { get; set; }
        public int ValorA { get; set; }
        public string Leyenda27 { get; set; }
        public int VentaA { get; set; }
        public int ValorB { get; set; }
        public string Leyenda28 { get; set; }
        public int VentaB { get; set; }
        public int ValorC { get; set; }
        public string Leyenda29 { get; set; }
        public int VentaC { get; set; }
        public int DirectaA { get; set; }
        public int DirectaB { get; set; }
        public int DirectaC { get; set; }
        public int BonoValorA { get; set; }
        public int BonoValorB { get; set; }
        public int BonoValorC { get; set; }
        public int BonoDirectaA { get; set; }
        public int BonoDirectaB { get; set; }
        public int BonoDirectaC { get; set; }
        public double FC1RangoInicial { get; set; }
        public double FC1RangoFinal { get; set; }
        public string Leyenda6 { get; set; }
        public double Puntos1 { get; set; }
        public double FC2RangoInicial { get; set; }
        public double FC2RangoFinal { get; set; }
        public string Leyenda7 { get; set; }
        public double Puntos2 { get; set; }
        public double FC3RangoInicial { get; set; }
        public double FC3RangoFinal { get; set; }
        public string Leyenda8 { get; set; }
        public double Puntos3 { get; set; }
        public double SF1RangoInicial { get; set; }
        public double SF1RangoFinal { get; set; }
        public string Leyenda11 { get; set; }
        public double Puntos4 { get; set; }
        public double SF2RangoInicial { get; set; }
        public double SF2RangoFinal { get; set; }
        public string Leyenda12 { get; set; }
        public double Puntos5 { get; set; }
        public double SF3RangoInicial { get; set; }
        public double SF3RangoFinal { get; set; }
        public string Leyenda13 { get; set; }
        public double Puntos6 { get; set; }
        public double SF4RangoInicial { get; set; }
        public double SF4RangoFinal { get; set; }
        public string Leyenda21 { get; set; }
        public double Puntos21 { get; set; }
        public double SF5RangoInicial { get; set; }
        public double SF5RangoFinal { get; set; }
        public string Leyenda22 { get; set; }
        public double Puntos22 { get; set; }
        public double EF1RangoInicial { get; set; }
        public double EF1RangoFinal { get; set; }
        public string Leyenda15 { get; set; }
        public double Puntos7 { get; set; }
        public double EF2RangoInicial { get; set; }
        public double EF2RangoFinal { get; set; }
        public string Leyenda16 { get; set; }
        public double Puntos8 { get; set; }
        public double EF3RangoInicial { get; set; }
        public double EF3RangoFinal { get; set; }
        public string Leyenda17 { get; set; }
        public double Puntos9 { get; set; }
        public double EF4RangoInicial { get; set; }
        public double EF4RangoFinal { get; set; }
        public string Leyenda23 { get; set; }
        public double Puntos23 { get; set; }
        public double EF5RangoInicial { get; set; }
        public double EF5RangoFinal { get; set; }
        public string Leyenda24 { get; set; }
        public double Puntos24 { get; set; }
        public double EF6RangoInicial { get; set; }
        public double EF6RangoFinal { get; set; }
        public string Leyenda25 { get; set; }
        public double Puntos25 { get; set; }
        public double EF7RangoInicial { get; set; }
        public double EF7RangoFinal { get; set; }
        public string Leyenda26 { get; set; }
        public double Puntos26 { get; set; }
        public string Leyenda20 { get; set; }
        public double VentasExits { get; set; }
        public int IdSegmento1 { get; set; }
        public string DirCheckIn { get; set; }
        public bool Reporte { get; set; }
        public bool DelClub { get; set; }
        public bool EnLinea { get; set; }
        public string CtaCostoVenta { get; set; }
        public bool EsCondominio { get; set; }
        public string CtaInteresDevengado { get; set; }
        public int IdCategoria { get; set; }
        public bool DelNetCenter { get; set; }
        public bool DePlusOne { get; set; }
        public bool HotelAsignado { get; set; }
        public string RazonSocial { get; set; }
        public bool TRMmkt { get; set; }
        public string GrupoTRM { get; set; }
        public string Code { get; set; }

        public bool Activo { get; set; }
        int maximoConsec = 0;   
         

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Hoteles);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Hoteles);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        public void LeerHotel(int idHotel)
        {
            string sql = "selecT*from Hoteles where idHotel=@idHotel";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;

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
            int idSala = 0;
            string sql = "select idHotel,idSalaVta from Hoteles where " + campo + " = '"+valor+"'";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Existe = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            idSala = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        }
                    }
                    con.Close();
                }
            }

            Activo = idSala > 0 ? true : false;

            return Existe;

        }

        private void MaxConsec()
        {
            maximoConsec = 0;

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                string sql = "select Max(idHotel) from Hoteles";

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
        }

        public void InsertHotel()
        {
            MaxConsec();

            string sql = "insert into Hoteles VALUES (@Max, @Codigo, @Nombre, @idSalaVta, "+
            "'Cancun', 'NULL', 'NULL', 'True', @idUsr, SYSDATETIME()" +
            ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'NULL', 0, 0,'NULL', 0, 0, " +
            "'NULL', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'NULL', 0, 0, 0,'NULL', 0, 0, 0," +
            "'NULL', 0, 0, 0,'NULL', 0, 0, 0,'NULL', 0, 0, 0,'NULL', 0, 0, 0, '', 0, 0, 0," +
            "'', 0, 0, 0,'NULL', 0, 0, 0,'NULL', 0, 0, 0,'NULL', 0, 0, 0, '', 0, 0, 0, ''," +
            "0, 0, 0, '', 0, 0, 0, '', 0,'NULL', 0, 2,'NULL', 1, 1, 1,'NULL', 0,'NULL', 0," +
            "0, 0, 1,'NULL', 0, 'OASIS', 'NULL')";

            using (SqlConnection conn = new SqlConnection(cx.cadenaConexion))
            {
                conn.Open();

                using (SqlCommand comando = new SqlCommand(sql, conn))
                {
                    comando.Parameters.Add("@Max", SqlDbType.Int).Value = maximoConsec + 1;
                    comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                    comando.Parameters.Add("@idSalaVta", SqlDbType.Int).Value = idSalaVta;
                    comando.Parameters.Add("@idUsr", SqlDbType.Int).Value = Sesion.ID;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void ModificaHotel(Hoteles h, string campo, string anterior, string nuevo)
        {
            string sql = nuevo == "" ? "UPDATE Hoteles set " + campo + "=null  where idHotel = @idHotel"
                                     : "UPDATE Hoteles set " + campo + "= '" + nuevo + "' where idHotel = @idHotel";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@idHotel", SqlDbType.Int).Value = h.idHotel;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }

            bita.RegistrarBitacora(100000, "Hoteles", campo+ " (idHotel: "+ h.idHotel+")", "U", anterior, nuevo);
        }

    }
}
