using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class Departamentos
    {
        Conexion cx = new Conexion();

        public int idDepto { get; set; }
        public string Nombre { get; set; }
        public int IdDivision { get; set; }
        public string idStatus { get; set; }
        public int IdUsuarioAlt { get; set; }
        public DateTime Fechoralt { get; set; }

        public void Limpiar()
        {
            idDepto = 0;
            Nombre = "";
            IdDivision = 0;
            idStatus = "";
            IdUsuarioAlt = 0;
            Fechoralt = Convert.ToDateTime("01/01/50");
        }

        public void LeerDepartamentos(int valor)
        {
            string sql = "selecT*from Departamentos where idDepto=@valor";

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
                            idDepto = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            IdDivision = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                            idStatus = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            IdUsuarioAlt = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                            Fechoralt = reader.IsDBNull(5) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(5);
                        }
                    }

                    con.Close();
                }
            }
        }

    }
}
