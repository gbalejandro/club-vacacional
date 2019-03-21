using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class TiposPago
    {
        Conexion c = new Conexion();

        public int idTippag { get; set; }
        public string Nombre { get; set; }
        public string Idioma2 { get; set; }
        public int GrupoPago { get; set; }
        public string SumRes { get; set; }
        public string PermiteCxl { get; set; }
        public int idTipPagCxl { get; set; }
        public string ShowEdoCta { get; set; }
        public string ShowInCobro { get; set; }

        public void LeerTiposPago(int valor)
        {
            string sql = "select * from TiposPago where idTippag=@valor";

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
                            idTippag = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            Idioma2 = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            GrupoPago = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                            SumRes = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            PermiteCxl = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            idTipPagCxl = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                            ShowEdoCta = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            ShowInCobro = reader.IsDBNull(8) ? "" : reader.GetString(8);
                        }
                    }

                    con.Close();
                }
            }
        }


    }
}
