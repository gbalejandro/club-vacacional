using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class Nacionalidades
    {
        Conexion cx = new Conexion();

        public int idNacionalidad { get; set; }
        public string Nombre { get; set; }
        public string IdAlias { get; set; }
        public string Idioma2 { get; set; }
        public string Idioma3 { get; set; }
        public string Idioma4 { get; set; }
        public string Idioma5 { get; set; }
        public int IdUsuarioAlt { get; set; }
        public DateTime Fechoralt { get; set; }
        public int idGrupoNacionalidad { get; set; }

        public void Limpiar()
        {
            idNacionalidad = 0;
            Nombre = "";
            IdAlias = "";
            Idioma2 = "";
            Idioma3 = "";
            Idioma4 = "";
            Idioma5 = "";
            IdUsuarioAlt = 0;
            Fechoralt = Convert.ToDateTime("01/01/50");
            idGrupoNacionalidad = 0;
        }


        public void LeerNacionalidad(int valor)
        {
            string sql = "select*from Nacionalidades where idNacionalidad=@valor";

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
                            idNacionalidad = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            IdAlias = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            Idioma2 = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            Idioma3 = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            Idioma4 = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            Idioma5 = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            IdUsuarioAlt = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                            Fechoralt = reader.IsDBNull(8) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(8);
                            idGrupoNacionalidad = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                        }
                    }

                    con.Close();
                }
            }
        }

    }
}
