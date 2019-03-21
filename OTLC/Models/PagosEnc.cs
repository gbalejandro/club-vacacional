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
    class PagosEnc
    {
        Conexion cx = new Conexion();

        public int FolioContrato { get; set; }
        public int NoArregloM { get; set; }
        public int NoMensualidad { get; set; }
        public double ImporteMensualidad { get; set; }
        public double ImporteCapital { get; set; }
        public double ImporteInteres { get; set; }
        public double PorDsctoCapital { get; set; }
        public double ImporteDsctoCapital { get; set; }
        public double PorDsctoInteres { get; set; }
        public double ImporteDsctoInteres { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double Saldo { get; set; }
        public double SaldoCapital { get; set; }
        public double SaldoInteres { get; set; }
        public string Pagado { get; set; }
        public double InteresCondonado { get; set; }
        public DateTime FechaPago { get; set; }
        public string Adelantada { get; set; }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(PagosEnc);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(PagosEnc);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        private void Limpiar(PagosEnc p)
        {
            //FolioContrato = 0;
            //NoArregloM = 0;
            //NoMensualidad = 0;
            ImporteMensualidad = 0;
            ImporteCapital = 0;
            ImporteInteres = 0;
            PorDsctoCapital = 0;
            ImporteDsctoCapital = 0;
            PorDsctoInteres = 0;
            ImporteDsctoInteres = 0;
            FechaVencimiento = Convert.ToDateTime("01/01/50");
            Saldo = 0;
            SaldoCapital = 0;
            SaldoInteres = 0;
            Pagado = "false";
            InteresCondonado = 0;
            FechaPago = Convert.ToDateTime("01/01/50");
            Adelantada = "false";
        }

        public void LeerPagoEnc(PagosEnc p)
        {
            Limpiar(p);
            string sql = "select*from PagosEnc where FolioContrato=@Folio and NoMensualidad=@Mensualidad and NoArregloM=@Arreglo and Pagado='True'";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = p.FolioContrato;
                    comando.Parameters.Add("@Mensualidad", SqlDbType.Int).Value = p.NoMensualidad;
                    comando.Parameters.Add("@Arreglo", SqlDbType.Int).Value = p.NoArregloM;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                p[reader.GetName(i)] = reader.IsDBNull(i) ? cx.getNullValue(p[reader.GetName(i)]) : reader.GetValue(i);
                            }
                        }
                    }
                    con.Close();
                }
            }
        }

        public int NoMensPagadas(int Folio, int arreglo)
        {
            int pagos = 0;
            string sql = "select Count(*) from PagosEnc where FolioContrato=@Folio and NoArregloM=@Arreglo and Pagado='True'";
            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio;
                    comando.Parameters.Add("@Arreglo", SqlDbType.Int).Value = arreglo;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pagos = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }

                    con.Close();
                }

            }
            return pagos;
        }
    }
}
