using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTLC.Models
{
    class Ciudades
    {
        Conexion cx = new Conexion();
        Estados ed = new Estados();


        public int idCiudad { get; set; }
        public string Nombre { get; set; }
        public int idEstado { get; set; }
        public string Idioma2 { get; set; }
        public string Idioma3 { get; set; }
        public string Idioma4 { get; set; }
        public string Idioma5 { get; set; }
        public int IdUsuarioAlt { get; set; }
        public DateTime Fechoralt { get; set; }
        public int IdEstadoOK { get; set; }

        public int idPais { get; set; }

        public void Limpiar()
        {
            idCiudad = 0;
            Nombre = "";
            idEstado = 0;
            Idioma2 = "";
            Idioma3 = "";
            Idioma4 = "";
            Idioma5 = "";
            IdUsuarioAlt = 0;
            Fechoralt = Convert.ToDateTime("01/01/50");
            IdEstadoOK = 0;
            idPais = 0;
        }

        public void LeerCiudad(int valor)
        {
            Limpiar();
            string sql = "select c.*,e.idPais from Ciudades c "+
                         "left join Estados e on c.idEstado=e.idEstado " +
                         "left join paises p on e.idPais=p.idPais where c.idCiudad = @valor";

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
                            idCiudad    = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Nombre      = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            idEstado    = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                            Idioma2     = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            Idioma3     = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            Idioma4     = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            Idioma5     = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            IdUsuarioAlt= reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                            Fechoralt   = reader.IsDBNull(8) ? Convert.ToDateTime("01/01/50") : reader.GetDateTime(8);
                            IdEstadoOK  = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);

                            idPais = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
                        }
                    }

                    con.Close();
                }

            }
        }


    }
}
