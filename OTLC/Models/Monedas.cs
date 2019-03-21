using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class Monedas
    {
        Conexion c = new Conexion();

        public int idMoneda { get; set; }
        public string Nombre { get; set; }
        public string NombreCortoMinusculas { get; set; }
        public string NombreCortoMayusculas { get; set; }
        public string CodigoFactura { get; set; }

        public void Limpiar()
        {
            idMoneda = 0;
            Nombre = "";
            NombreCortoMinusculas = "";
            NombreCortoMayusculas = "";
            CodigoFactura = "";
        }
            
        public void LeerMoneda(int valor)
        {
            string sql = "select * from Monedas where idMoneda=@valor";

            using (SqlConnection con = new SqlConnection(c.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@valor", SqlDbType.Int).Value = valor;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idMoneda =              reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre =                reader.IsDBNull(1) ? "" : reader.GetString(1);
                            NombreCortoMinusculas = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            NombreCortoMayusculas = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            CodigoFactura =         reader.IsDBNull(4) ? "" : reader.GetString(4);
                        }
                    }

                    con.Close();
                }
            }
        }

    }
}
