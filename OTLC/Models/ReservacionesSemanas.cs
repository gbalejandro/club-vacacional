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
    class ReservacionesSemanas
    {
        Conexion cx = new Conexion();

        public int IdTipo { get; set; }
        public int IdHotel { get; set; }
        public int IdHabitacion { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaVentaInicio { get; set; }
        public DateTime FechaVentaFinal { get; set; }
        public int SemanasDescontar { get; set; }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(ReservacionesSemanas);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(ReservacionesSemanas);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        public void InsertSemanas(DateTime FI, DateTime FF, int Pts )
        {
            string sql = "insert into ReservacionesSemanas values "+
                " (@IdHotel, @IdHabitacion, @Codigo, @FecIni,@FecFin,@Semanas)";

            using (SqlConnection conn = new SqlConnection(cx.cadenaConexion))
            {
                conn.Open();

                using (SqlCommand comando = new SqlCommand(sql, conn))
                {
                    comando.Parameters.Add("@IdHotel", SqlDbType.Int).Value = IdHotel;
                    comando.Parameters.Add("@IdHabitacion", SqlDbType.Int).Value = IdHabitacion;
                    comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo;
                    comando.Parameters.Add("@FecIni", SqlDbType.DateTime).Value = FI;
                    comando.Parameters.Add("@FecFin", SqlDbType.DateTime).Value = FF;
                    comando.Parameters.Add("@Semanas", SqlDbType.Int).Value = Pts;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        /*
        public void UpdateSemanas(DateTime FI, DateTime FF, int Pts)
        {
            string sql = "update ReservacionesSemanas set  values " +
                " (@IdHotel, @IdHabitacion, @Codigo, @FecIni,@FecFin,@Semanas)";

            using (SqlConnection conn = new SqlConnection(cx.cadenaConexion))
            {
                conn.Open();

                using (SqlCommand comando = new SqlCommand(sql, conn))
                {
                    comando.Parameters.Add("@IdHotel", SqlDbType.Int).Value = IdHotel;
                    comando.Parameters.Add("@IdHabitacion", SqlDbType.Int).Value = IdHabitacion;
                    comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo;
                    comando.Parameters.Add("@FecIni", SqlDbType.DateTime).Value = FI;
                    comando.Parameters.Add("@FecFin", SqlDbType.DateTime).Value = FF;
                    comando.Parameters.Add("@Semanas", SqlDbType.Int).Value = Pts;

                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

    */



    }
}
