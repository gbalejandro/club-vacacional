using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class Estados
    {
        Conexion cx = new Conexion();

        public int idEstado { get; set; }
        public string Nombre { get; set; }
        public string idAlias { get; set; }
        public int idPais { get; set; }
        public string Idioma2 { get; set; }
        public string Idioma3 { get; set; }
        public string Idioma4 { get; set; }
        public string Idioma5 { get; set; }
        public int IdUsuarioAlt { get; set; }
        public DateTime Fechoralt { get; set; }
        public bool IdEstatus { get; set; }
        public int idPaisNew { get; set; }
        public int idPaisOld { get; set; }


        public void Limpiar()
        {
            idEstado = 0;
            Nombre = "";
            idAlias = "";
            idPais = 0;
            Idioma2 = "";
            Idioma3 = "";
            Idioma4 = "";
            Idioma5 = "";
            IdUsuarioAlt = 0;
            Fechoralt = Convert.ToDateTime("01/01/50");
            IdEstatus = false;
            idPaisNew = 0;
            idPaisOld = 0;
        }

        public void LeerEstado(int valor)
        {
            Limpiar();

            string sql = "select*from Estados where idEstado=@valor";

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
                            idEstado = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            idAlias= reader.IsDBNull(2) ? "" : reader.GetString(2);
                            idPais = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                            Idioma2 = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            Idioma3 = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            Idioma4 = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            Idioma5 = reader.IsDBNull(7) ? "" : reader.GetString(7);                      
                            IdUsuarioAlt = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                            Fechoralt = reader.IsDBNull(9) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(9);
                            IdEstatus = reader.IsDBNull(10) ? false : reader.GetBoolean(10);
                            idPaisNew = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                            idPaisOld = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);

                        }
                    }

                    con.Close();
                }
            }
        }

    }
}
