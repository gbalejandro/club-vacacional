using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class Paises
    {
        Conexion cx = new Conexion();

        public int idPais { get; set; }
        public string Nombre { get; set; }
        public string idAlias { get; set; }
        public string Idioma2 { get; set; }
        public string Idioma3 { get; set; }
        public string Idioma4 { get; set; }
        public string Idioma5 { get; set; }
        public int idUsuarioAlt { get; set; }
        public DateTime Fechoralt { get; set; }
        public int IdRegion { get; set; }
        public bool IdEstatus { get; set; }
        public int idPaisNew { get; set; }

        public void Limpiar()
        {
            idPais = 0;
            Nombre = "";
            idAlias = "";
            Idioma2 = "";
            Idioma3 = "";
            Idioma4 = "";
            Idioma5 = "";
            idUsuarioAlt = 0;
            Fechoralt = Convert.ToDateTime("01/01/50");
            IdRegion = 0;
            IdEstatus = false;
            idPaisNew = 0;
        }

        public void LeerPais(int valor)
        {
            string sql = "select*from Paises where idPais=@valor";

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
                            idPais = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            idAlias = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            Idioma2 = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            Idioma3 = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            Idioma4 = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            Idioma5 = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            idUsuarioAlt = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                            Fechoralt = reader.IsDBNull(8) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(8);
                            IdRegion = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                            IdEstatus= reader.IsDBNull(10) ? false : reader.GetBoolean(10);
                            idPaisNew = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                        }
                    }

                    con.Close();
                }
            }
        }



    }
}
