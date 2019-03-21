using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class EdoCivil
    {
        Conexion cx = new Conexion();

        public int idEdoCivil { get; set; }
        public string Nombre { get; set; }
        public string Idioma2 { get; set; }
        public int Pax { get; set; }
        public string Idioma3 { get; set; }
        public string Idioma4 { get; set; }
        public string Idioma5 { get; set; }
        public bool Activo { get; set; }

        public void Limpiar()
        {
            idEdoCivil = 0;
            Nombre = "";
            Idioma2 = "";
            Pax = 0;
            Idioma3 = "";
            Idioma4 = "";
            Idioma5 = "";
            Activo = false;       
        }

        public void LeerEdoCivil(int valor)
        {
            string sql = "select*from EdoCivil where idEdoCivil=@valor";

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
                            idEdoCivil = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            Idioma2 = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            Pax = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                            Idioma3 = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            Idioma4 = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            Idioma5 = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            Activo = reader.IsDBNull(7) ? false : reader.GetBoolean(7);
                        }
                    }

                    con.Close();
                }
            }
        }
    }
}
