using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class TiposPersona
    {
        Conexion cx = new Conexion();

        public int idTipoPersona { get; set; }
        public string Nombre { get; set; }
        public string Idioma2 { get; set; }
        public string Idioma3 { get; set; }
        public string Idioma4 { get; set; }
        public string Idioma5 { get; set; }

        public void Limpiar()
        {
            idTipoPersona = 0;
            Nombre = "";
            Idioma2 = "";
            Idioma3 = "";
            Idioma4 = "";
            Idioma5 = "";
        }

        public void LeerTipoPersona(int valor)
        {
            string sql = "select*from TiposPersona where idTipoPersona=@valor";

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
                            idTipoPersona   = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre          = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            Idioma2         = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            Idioma3         = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            Idioma4         = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            Idioma5         = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        }
                    }

                    con.Close();
                }
            }
        }


    }
}
