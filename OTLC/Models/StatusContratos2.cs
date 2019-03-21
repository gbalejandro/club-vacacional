using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class StatusContratos2
    {
        Conexion cx = new Conexion();

        public int idStatusCon2 { get; set; }
        public string Nombre { get; set; }
        public int ColorFondo { get; set; }
        public int ColorFuente { get; set; }

        public void Limpiar()
        {
            idStatusCon2 = 0;
            Nombre = "";
            ColorFondo = 0;
            ColorFuente = 0;
        }

        public void LeerStatus2(int valor)
        {
            string sql = "select*from StatusContratos2 where idStatusCon2=@valor";

            using (SqlConnection con = new SqlConnection(cx.cadenaConexion))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@valor", SqlDbType.Int).Value = valor;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idStatusCon2 = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            ColorFondo = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                            ColorFuente = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        }
                    }

                    con.Close();
                }
            }
        }

    }
}
