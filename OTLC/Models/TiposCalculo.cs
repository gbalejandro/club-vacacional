using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class TiposCalculo
    {
        Conexion cx = new Conexion();

        public int idTipoCalculo { get; set; }
        public string NOmbre { get; set; }

        public void Limpiar()
        {
            idTipoCalculo = 0;
            NOmbre = "";
        }

        public void LeerTiposCalculo(int valor)
        {
            string sql = "select * from  TiposCalculo where idTipoCalculo=@valor";

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
                            idTipoCalculo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            NOmbre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        }
                    }

                    con.Close();
                }
            }
        }
    }
}
