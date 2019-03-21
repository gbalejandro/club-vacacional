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
    class Arreglos
    {
        Conexion cx = new Conexion();

        public int FolioContrato { get; set; }
        public int NoArregloM { get; set; }
        public DateTime FechaArreglo { get; set; }
        public string AcumularDsctosEnPagos { get; set; }
        public double Saldo { get; set; }
        public double SaldoCapital { get; set; }
        public double SaldoInteres { get; set; }
        public double ImporteMensualidadesPagadas { get; set; }
        public double SaldoActual { get; set; }
        public double PorEnganchePac { get; set; }
        public double EnganchePactado { get; set; }
        public double EngancheCobrado { get; set; }
        public double PorEngancheCob { get; set; }
        public double EngancheDiferido { get; set; }
        public double SaldoContrato { get; set; }
        public int NoEnganchesDiferidos { get; set; }
        public string UsarTazaInteres { get; set; }
        public int CalcularMensualidadSobre { get; set; }
        public int Plazo { get; set; }
        public double TazaInteres { get; set; }
        public double ImporteMensualidad { get; set; }
        public double SaldoFinanciadoInicial { get; set; }
        public DateTime FecprimmenActual { get; set; }
        public DateTime Fecultmen { get; set; }
        public int NoMensualidadesPagadas { get; set; }
        public double SaldoFinanciadoActual { get; set; }
        public int TipoCalculo { get; set; }
        public double SaldoInicial { get; set; }
        public double CargoTC1 { get; set; }
        public string MensualidadTC1 { get; set; }
        public double CargoTC2 { get; set; }
        public string MensualidadTC2 { get; set; }
        public int idUsuarioAlta { get; set; }
        public DateTime FechaHoraAlta { get; set; }
        public int NoMensualidadesAdelantadas { get; set; }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Arreglos);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Arreglos);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        public int NoArregloMax(int folio)
        {
            int MaxNoArreglo = 0;
            string sql = "select MAX(NoArregloM) from ArreglosMensualidades where FolioContrato=@Folio";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = folio;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaxNoArreglo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }
            return MaxNoArreglo;
        }

        public void LeerArreglo(int folio,int arreglo)
        {
           // Limpiar();
            string sql = "select*from ArreglosMensualidades where FolioContrato=@Folio and NoArregloM=@Arreglo";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@Folio", SqlDbType.Int).Value = folio;
                    comando.Parameters.Add("@Arreglo", SqlDbType.Int).Value = arreglo;
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

    }
}
